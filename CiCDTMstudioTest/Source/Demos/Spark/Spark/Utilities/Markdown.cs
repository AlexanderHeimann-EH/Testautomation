namespace Spark.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Markdown
    {
        private static Regex _amps = new Regex("&(?!(#[0-9]+)|(#[xX][a-fA-F0-9])|([a-zA-Z][a-zA-Z0-9]*);)", RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        private static Regex _anchorInline = new Regex(string.Format("\r\n                (                           # wrap whole match in $1\r\n                    \\[\r\n                        ({0})               # link text = $2\r\n                    \\]\r\n                    \\(                      # literal paren\r\n                        [ ]*\r\n                        ({1})               # href = $3\r\n                        [ ]*\r\n                        (                   # $4\r\n                        (['\"])           # quote char = $5\r\n                        (.*?)               # title = $6\r\n                        \\5                  # matching quote\r\n                        [ ]*                # ignore any spaces between closing quote and )\r\n                        )?                  # title is optional\r\n                    \\)\r\n                )", GetNestedBracketsPattern(), GetNestedParensPattern()), RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex _anchorRef = new Regex(string.Format("\r\n            (                               # wrap whole match in $1\r\n                \\[\r\n                    ({0})                   # link text = $2\r\n                \\]\r\n\r\n                [ ]?                        # one optional space\r\n                (?:\\n[ ]*)?                 # one optional newline followed by spaces\r\n\r\n                \\[\r\n                    (.*?)                   # id = $3\r\n                \\]\r\n            )", GetNestedBracketsPattern()), RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex _anchorRefShortcut = new Regex("\r\n            (                               # wrap whole match in $1\r\n              \\[\r\n                 ([^\\[\\]]+)                 # link text = $2; can't contain [ or ]\r\n              \\]\r\n            )", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex _angles = new Regex(@"<(?![A-Za-z/?\$!])", RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        private bool _autoHyperlink;
        private static Regex _autolinkBare = new Regex(@"(^|\s)(https?|ftp)(://[-A-Z0-9+&@#/%?=~_|\[\]\(\)!:,\.;]*[-A-Z0-9+&@#/%=~_|\[\]])($|\W)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private bool _autoNewlines;
        private static Regex _backslashEscapes;
        private static readonly Dictionary<string, string> _backslashEscapeTable = new Dictionary<string, string>();
        private static Regex _blockquote = new Regex("\r\n            (                           # Wrap whole match in $1\r\n                (\r\n                ^[ ]*>[ ]?              # '>' at the start of a line\r\n                    .+\\n                # rest of the first line\r\n                (.+\\n)*                 # subsequent consecutive lines\r\n                \\n*                     # blanks\r\n                )+\r\n            )", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);
        private static Regex _blocksHtml = new Regex(GetBlockPattern(), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
        private static Regex _bold = new Regex(@"(\*\*|__) (?=\S) (.+?[*_]*) (?<=\S) \1", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex _codeBlock = new Regex(string.Format("\r\n                    (?:\\n\\n|\\A\\n?)\r\n                    (                        # $1 = the code block -- one or more lines, starting with a space\r\n                    (?:\r\n                        (?:[ ]{{{0}}})       # Lines must start with a tab-width of spaces\r\n                        .*\\n+\r\n                    )+\r\n                    )\r\n                    ((?=^[ ]{{0,{0}}}\\S)|\\Z) # Lookahead for non-space at line-start, or end of doc", 4), RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);
        private static Regex _codeEncoder = new Regex(@"&|<|>|\\|\*|_|\{|\}|\[|\]", RegexOptions.Compiled);
        private static Regex _codeSpan = new Regex("\r\n                    (?<!\\\\)   # Character before opening ` can't be a backslash\r\n                    (`+)      # $1 = Opening run of `\r\n                    (.+?)     # $2 = The code block\r\n                    (?<!`)\r\n                    \\1\r\n                    (?!`)", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private string _emptyElementSuffix;
        private bool _encodeProblemUrlCharacters;
        private static readonly Dictionary<string, string> _escapeTable = new Dictionary<string, string>();
        private static Regex _headerAtx = new Regex("\r\n                ^(\\#{1,6})  # $1 = string of #'s\r\n                [ ]*\r\n                (.+?)       # $2 = Header text\r\n                [ ]*\r\n                \\#*         # optional closing #'s (not counted)\r\n                \\n+", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);
        private static Regex _headerSetext = new Regex("\r\n                ^(.+?)\r\n                [ ]*\r\n                \\n\r\n                (=+|-+)     # $1 = string of ='s or -'s\r\n                [ ]*\r\n                \\n+", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);
        private static Regex _horizontalRules = new Regex("\r\n            ^[ ]{0,3}         # Leading space\r\n                ([-*_])       # $1: First marker\r\n                (?>           # Repeated marker group\r\n                    [ ]{0,2}  # Zero, one, or two spaces.\r\n                    \\1        # Marker character\r\n                ){2,}         # Group repeated at least twice\r\n                [ ]*          # Trailing spaces\r\n                $             # End of line.\r\n            ", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);
        private readonly Dictionary<string, string> _htmlBlocks;
        private static Regex _htmlTokens = new Regex("\r\n            (<!(?:--.*?--\\s*)+>)|        # match <!-- foo -->\r\n            (<\\?.*?\\?>)|                 # match <?foo?> " + RepeatString(" \r\n            (<[A-Za-z\\/!$](?:[^<>]|", 6) + RepeatString(")*>)", 6) + " # match <tag> and </tag>", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.Multiline);
        private static Regex _imagesInline = new Regex(string.Format("\r\n              (                     # wrap whole match in $1\r\n                !\\[\r\n                    (.*?)           # alt text = $2\r\n                \\]\r\n                \\s?                 # one optional whitespace character\r\n                \\(                  # literal paren\r\n                    [ ]*\r\n                    ({0})           # href = $3\r\n                    [ ]*\r\n                    (               # $4\r\n                    (['\"])       # quote char = $5\r\n                    (.*?)           # title = $6\r\n                    \\5              # matching quote\r\n                    [ ]*\r\n                    )?              # title is optional\r\n                \\)\r\n              )", GetNestedParensPattern()), RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex _imagesRef = new Regex("\r\n                    (               # wrap whole match in $1\r\n                    !\\[\r\n                        (.*?)       # alt text = $2\r\n                    \\]\r\n\r\n                    [ ]?            # one optional space\r\n                    (?:\\n[ ]*)?     # one optional newline followed by spaces\r\n\r\n                    \\[\r\n                        (.*?)       # id = $3\r\n                    \\]\r\n\r\n                    )", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Dictionary<string, string> _invertedEscapeTable = new Dictionary<string, string>();
        private static Regex _italic = new Regex(@"(\*|_) (?=\S) (.+?) (?<=\S) \1", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex _leadingWhitespace = new Regex("^[ ]*", RegexOptions.Compiled);
        private static Regex _linkDef = new Regex(string.Format("\r\n                        ^[ ]{{0,{0}}}\\[(.+)\\]:  # id = $1\r\n                          [ ]*\r\n                          \\n?                   # maybe *one* newline\r\n                          [ ]*\r\n                        <?(\\S+?)>?              # url = $2\r\n                          [ ]*\r\n                          \\n?                   # maybe one newline\r\n                          [ ]*\r\n                        (?:\r\n                            (?<=\\s)             # lookbehind for whitespace\r\n                            [\"(]\r\n                            (.+?)               # title = $3\r\n                            [\")]\r\n                            [ ]*\r\n                        )?                      # title is optional\r\n                        (?:\\n+|\\Z)", 3), RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);
        private bool _linkEmails;
        private int _listLevel;
        private static Regex _listNested = new Regex("^" + _wholeList, RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);
        private static Regex _listTopLevel = new Regex(@"(?:(?<=\n\n)|\A\n?)" + _wholeList, RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline);
        private const string _markerOL = @"\d+[.]";
        private const string _markerUL = "[*+-]";
        private const int _nestDepth = 6;
        private static string _nestedBracketsPattern;
        private static string _nestedParensPattern;
        private static Regex _newlinesLeadingTrailing = new Regex(@"^\n+|\n+\z", RegexOptions.Compiled);
        private static Regex _newlinesMultiple = new Regex(@"\n{2,}", RegexOptions.Compiled);
        private static Regex _outDent = new Regex("^[ ]{1," + 4 + "}", RegexOptions.Compiled | RegexOptions.Multiline);
        private static char[] _problemUrlChars = "\"'*()[]$:".ToCharArray();
        private static Regex _strictBold = new Regex(@"([\W_]|^) (\*\*|__) (?=\S) ([^\r]*?\S[\*_]*) \2 ([\W_]|$)", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private bool _strictBoldItalic;
        private static Regex _strictItalic = new Regex(@"([\W_]|^) (\*|_) (?=\S) ([^\r\*_]*?\S) \2 ([\W_]|$)", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);
        private const int _tabWidth = 4;
        private readonly Dictionary<string, string> _titles;
        private static Regex _unescapes = new Regex("\x001a\\d+\x001a", RegexOptions.Compiled);
        private readonly Dictionary<string, string> _urls;
        private const string _version = "1.12";
        private static string _wholeList = string.Format("\r\n            (                               # $1 = whole list\r\n              (                             # $2\r\n                [ ]{{0,{1}}}\r\n                ({0})                       # $3 = first list item marker\r\n                [ ]+\r\n              )\r\n              (?s:.+?)\r\n              (                             # $4\r\n                  \\z\r\n                |\r\n                  \\n{{2,}}\r\n                  (?=\\S)\r\n                  (?!                       # Negative lookahead for another list item marker\r\n                    [ ]*\r\n                    {0}[ ]+\r\n                  )\r\n              )\r\n            )", string.Format("(?:{0}|{1})", "[*+-]", @"\d+[.]"), 3);

        static Markdown()
        {
            string str = "";
            foreach (char ch in @"\`*_{}[]()>#+-.!")
            {
                string s = ch.ToString();
                string hashKey = GetHashKey(s);
                _escapeTable.Add(s, hashKey);
                _invertedEscapeTable.Add(hashKey, s);
                _backslashEscapeTable.Add(@"\" + s, hashKey);
                str = str + Regex.Escape(@"\" + s) + "|";
            }
            _backslashEscapes = new Regex(str.Substring(0, str.Length - 1), RegexOptions.Compiled);
        }

        public Markdown() : this(false)
        {
        }

        public Markdown(bool loadOptionsFromConfigFile)
        {
            this._emptyElementSuffix = " />";
            this._linkEmails = true;
            this._urls = new Dictionary<string, string>();
            this._titles = new Dictionary<string, string>();
            this._htmlBlocks = new Dictionary<string, string>();
            if (loadOptionsFromConfigFile)
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
                foreach (string str in appSettings.Keys)
                {
                    string str2 = str;
                    if (str2 != null)
                    {
                        if (!(str2 == "Markdown.AutoHyperlink"))
                        {
                            if (str2 == "Markdown.AutoNewlines")
                            {
                                goto Label_00CC;
                            }
                            if (str2 == "Markdown.EmptyElementSuffix")
                            {
                                goto Label_00E0;
                            }
                            if (str2 == "Markdown.EncodeProblemUrlCharacters")
                            {
                                goto Label_00EF;
                            }
                            if (str2 == "Markdown.LinkEmails")
                            {
                                goto Label_0103;
                            }
                            if (str2 == "Markdown.StrictBoldItalic")
                            {
                                goto Label_0117;
                            }
                        }
                        else
                        {
                            this._autoHyperlink = Convert.ToBoolean(appSettings[str]);
                        }
                    }
                    continue;
                Label_00CC:
                    this._autoNewlines = Convert.ToBoolean(appSettings[str]);
                    continue;
                Label_00E0:
                    this._emptyElementSuffix = appSettings[str];
                    continue;
                Label_00EF:
                    this._encodeProblemUrlCharacters = Convert.ToBoolean(appSettings[str]);
                    continue;
                Label_0103:
                    this._linkEmails = Convert.ToBoolean(appSettings[str]);
                    continue;
                Label_0117:
                    this._strictBoldItalic = Convert.ToBoolean(appSettings[str]);
                }
            }
        }

        private string AnchorInlineEvaluator(Match match)
        {
            string str = match.Groups[2].Value;
            string url = match.Groups[3].Value;
            string str3 = match.Groups[6].Value;
            url = this.EncodeProblemUrlChars(url);
            url = this.EscapeBoldItalic(url);
            if (url.StartsWith("<") && url.EndsWith(">"))
            {
                url = url.Substring(1, url.Length - 2);
            }
            string str4 = string.Format("<a href=\"{0}\"", url);
            if (!string.IsNullOrEmpty(str3))
            {
                str3 = str3.Replace("\"", "&quot;");
                str3 = this.EscapeBoldItalic(str3);
                str4 = str4 + string.Format(" title=\"{0}\"", str3);
            }
            return (str4 + string.Format(">{0}</a>", str));
        }

        private string AnchorRefEvaluator(Match match)
        {
            string str = match.Groups[1].Value;
            string str2 = match.Groups[2].Value;
            string key = match.Groups[3].Value.ToLowerInvariant();
            if (key == "")
            {
                key = str2.ToLowerInvariant();
            }
            if (this._urls.ContainsKey(key))
            {
                string url = this._urls[key];
                url = this.EncodeProblemUrlChars(url);
                url = this.EscapeBoldItalic(url);
                string str4 = "<a href=\"" + url + "\"";
                if (this._titles.ContainsKey(key))
                {
                    string s = this._titles[key];
                    s = this.EscapeBoldItalic(s);
                    str4 = str4 + " title=\"" + s + "\"";
                }
                return (str4 + ">" + str2 + "</a>");
            }
            return str;
        }

        private string AnchorRefShortcutEvaluator(Match match)
        {
            string str = match.Groups[1].Value;
            string str2 = match.Groups[2].Value;
            string key = Regex.Replace(str2.ToLowerInvariant(), @"[ ]*\n[ ]*", " ");
            if (this._urls.ContainsKey(key))
            {
                string url = this._urls[key];
                url = this.EncodeProblemUrlChars(url);
                url = this.EscapeBoldItalic(url);
                string str4 = "<a href=\"" + url + "\"";
                if (this._titles.ContainsKey(key))
                {
                    string s = this._titles[key];
                    s = this.EscapeBoldItalic(s);
                    str4 = str4 + " title=\"" + s + "\"";
                }
                return (str4 + ">" + str2 + "</a>");
            }
            return str;
        }

        private string AtxHeaderEvaluator(Match match)
        {
            string text = match.Groups[2].Value;
            int length = match.Groups[1].Value.Length;
            return string.Format("<h{1}>{0}</h{1}>\n\n", this.RunSpanGamut(text), length);
        }

        private string BlockQuoteEvaluator(Match match)
        {
            string text = Regex.Replace(Regex.Replace(match.Groups[1].Value, "^[ ]*>[ ]?", "", RegexOptions.Multiline), "^[ ]+$", "", RegexOptions.Multiline);
            text = Regex.Replace(Regex.Replace(this.RunBlockGamut(text), "^", "  ", RegexOptions.Multiline), @"(\s*<pre>.+?</pre>)", new MatchEvaluator(this.BlockQuoteEvaluator2), RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
            return string.Format("<blockquote>\n{0}\n</blockquote>\n\n", text);
        }

        private string BlockQuoteEvaluator2(Match match)
        {
            return Regex.Replace(match.Groups[1].Value, "^  ", "", RegexOptions.Multiline);
        }

        private void Cleanup()
        {
            this.Setup();
        }

        private string CodeBlockEvaluator(Match match)
        {
            string block = match.Groups[1].Value;
            block = this.EncodeCode(this.Outdent(block));
            block = _newlinesLeadingTrailing.Replace(block, "");
            return ("\n\n<pre><code>" + block + "\n</code></pre>\n\n");
        }

        private string CodeSpanEvaluator(Match match)
        {
            string code = Regex.Replace(Regex.Replace(match.Groups[2].Value, "^[ ]*", ""), "[ ]*$", "");
            code = this.EncodeCode(code);
            return ("<code>" + code + "</code>");
        }

        private string DoAnchors(string text)
        {
            text = _anchorRef.Replace(text, new MatchEvaluator(this.AnchorRefEvaluator));
            text = _anchorInline.Replace(text, new MatchEvaluator(this.AnchorInlineEvaluator));
            text = _anchorRefShortcut.Replace(text, new MatchEvaluator(this.AnchorRefShortcutEvaluator));
            return text;
        }

        private string DoAutoLinks(string text)
        {
            if (this._autoHyperlink)
            {
                text = _autolinkBare.Replace(text, "$1<$2$3>$4");
            }
            text = Regex.Replace(text, "<((https?|ftp):[^'\">\\s]+)>", new MatchEvaluator(this.HyperlinkEvaluator));
            if (this._linkEmails)
            {
                string pattern = "<\r\n                      (?:mailto:)?\r\n                      (\r\n                        [-.\\w]+\r\n                        \\@\r\n                        [-a-z0-9]+(\\.[-a-z0-9]+)*\\.[a-z]+\r\n                      )\r\n                      >";
                text = Regex.Replace(text, pattern, new MatchEvaluator(this.EmailEvaluator), RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
            }
            return text;
        }

        private string DoBlockQuotes(string text)
        {
            return _blockquote.Replace(text, new MatchEvaluator(this.BlockQuoteEvaluator));
        }

        private string DoCodeBlocks(string text)
        {
            text = _codeBlock.Replace(text, new MatchEvaluator(this.CodeBlockEvaluator));
            return text;
        }

        private string DoCodeSpans(string text)
        {
            return _codeSpan.Replace(text, new MatchEvaluator(this.CodeSpanEvaluator));
        }

        private string DoHardBreaks(string text)
        {
            if (this._autoNewlines)
            {
                text = Regex.Replace(text, @"\n", string.Format("<br{0}\n", this._emptyElementSuffix));
                return text;
            }
            text = Regex.Replace(text, @" {2,}\n", string.Format("<br{0}\n", this._emptyElementSuffix));
            return text;
        }

        private string DoHeaders(string text)
        {
            text = _headerSetext.Replace(text, new MatchEvaluator(this.SetextHeaderEvaluator));
            text = _headerAtx.Replace(text, new MatchEvaluator(this.AtxHeaderEvaluator));
            return text;
        }

        private string DoHorizontalRules(string text)
        {
            return _horizontalRules.Replace(text, "<hr" + this._emptyElementSuffix + "\n");
        }

        private string DoImages(string text)
        {
            text = _imagesRef.Replace(text, new MatchEvaluator(this.ImageReferenceEvaluator));
            text = _imagesInline.Replace(text, new MatchEvaluator(this.ImageInlineEvaluator));
            return text;
        }

        private string DoItalicsAndBold(string text)
        {
            if (this._strictBoldItalic)
            {
                text = _strictBold.Replace(text, "$1<strong>$3</strong>$4");
                text = _strictItalic.Replace(text, "$1<em>$3</em>$4");
                return text;
            }
            text = _bold.Replace(text, "<strong>$2</strong>");
            text = _italic.Replace(text, "<em>$2</em>");
            return text;
        }

        private string DoLists(string text)
        {
            if (this._listLevel > 0)
            {
                text = _listNested.Replace(text, new MatchEvaluator(this.ListEvaluator));
                return text;
            }
            text = _listTopLevel.Replace(text, new MatchEvaluator(this.ListEvaluator));
            return text;
        }

        private string EmailEvaluator(Match match)
        {
            string addr = this.Unescape(match.Groups[1].Value);
            addr = "mailto:" + addr;
            addr = this.EncodeEmailAddress(addr);
            return Regex.Replace(string.Format("<a href=\"{0}\">{0}</a>", addr), "\">.+?:", "\">");
        }

        private string EncodeAmpsAndAngles(string s)
        {
            s = _amps.Replace(s, "&amp;");
            s = _angles.Replace(s, "&lt;");
            return s;
        }

        private string EncodeCode(string code)
        {
            return _codeEncoder.Replace(code, new MatchEvaluator(this.EncodeCodeEvaluator));
        }

        private string EncodeCodeEvaluator(Match match)
        {
            switch (match.Value)
            {
                case "&":
                    return "&amp;";

                case "<":
                    return "&lt;";

                case ">":
                    return "&gt;";
            }
            return _escapeTable[match.Value];
        }

        private string EncodeEmailAddress(string addr)
        {
            StringBuilder builder = new StringBuilder(addr.Length * 5);
            Random random = new Random();
            foreach (char ch in addr)
            {
                int num = random.Next(1, 100);
                if (((num > 90) || (ch == ':')) && (ch != '@'))
                {
                    builder.Append(ch);
                }
                else if (num < 0x2d)
                {
                    builder.AppendFormat("&#x{0:x};", (int) ch);
                }
                else
                {
                    builder.AppendFormat("&#{0};", (int) ch);
                }
            }
            return builder.ToString();
        }

        private string EncodeProblemUrlChars(string url)
        {
            if (!this._encodeProblemUrlCharacters)
            {
                return url;
            }
            StringBuilder builder = new StringBuilder(url.Length);
            for (int i = 0; i < url.Length; i++)
            {
                char ch = url[i];
                bool flag = Array.IndexOf<char>(_problemUrlChars, ch) != -1;
                if ((flag && (ch == ':')) && (i < (url.Length - 1)))
                {
                    flag = (url[i + 1] != '/') && ((url[i + 1] < '0') || (url[i + 1] > '9'));
                }
                if (flag)
                {
                    builder.Append("%" + string.Format("{0:x}", (byte) ch));
                }
                else
                {
                    builder.Append(ch);
                }
            }
            return builder.ToString();
        }

        private string EscapeBackslashes(string s)
        {
            return _backslashEscapes.Replace(s, new MatchEvaluator(this.EscapeBackslashesEvaluator));
        }

        private string EscapeBackslashesEvaluator(Match match)
        {
            return _backslashEscapeTable[match.Value];
        }

        private string EscapeBoldItalic(string s)
        {
            s = s.Replace("*", _escapeTable["*"]);
            s = s.Replace("_", _escapeTable["_"]);
            return s;
        }

        private string EscapeSpecialCharsWithinTagAttributes(string text)
        {
            List<Token> list = this.TokenizeHTML(text);
            StringBuilder builder = new StringBuilder(text.Length);
            foreach (Token token in list)
            {
                string s = token.Value;
                if (token.Type == TokenType.Tag)
                {
                    s = Regex.Replace(s.Replace(@"\", _escapeTable[@"\"]), "(?<=.)</?code>(?=.)", _escapeTable["`"]);
                    s = this.EscapeBoldItalic(s);
                }
                builder.Append(s);
            }
            return builder.ToString();
        }

        private string FormParagraphs(string text)
        {
            string[] strArray = _newlinesMultiple.Split(_newlinesLeadingTrailing.Replace(text, ""));
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].StartsWith("\x001a"))
                {
                    strArray[i] = this._htmlBlocks[strArray[i]];
                }
                else
                {
                    strArray[i] = _leadingWhitespace.Replace(this.RunSpanGamut(strArray[i]), "<p>") + "</p>";
                }
            }
            return string.Join("\n\n", strArray);
        }

        private static string GetBlockPattern()
        {
            string newValue = "ins|del";
            string str2 = "p|div|h[1-6]|blockquote|pre|table|dl|ol|ul|address|script|noscript|form|fieldset|iframe|math";
            string str3 = "\r\n            (?>\t\t\t\t            # optional tag attributes\r\n              \\s\t\t\t            # starts with whitespace\r\n              (?>\r\n                [^>\"/]+\t            # text outside quotes\r\n              |\r\n                /+(?!>)\t\t            # slash not followed by >\r\n              |\r\n                \"[^\"]*\"\t\t        # text inside double quotes (tolerate >)\r\n              |\r\n                '[^']*'\t                # text inside single quotes (tolerate >)\r\n              )*\r\n            )?\t\r\n            ";
            string str4 = RepeatString("\r\n                (?>\r\n                  [^<]+\t\t\t        # content without tag\r\n                |\r\n                  <\\2\t\t\t        # nested opening tag\r\n                    " + str3 + "       # attributes\r\n                  (?>\r\n                      />\r\n                  |\r\n                      >", 6) + ".*?" + RepeatString("\r\n                      </\\2\\s*>\t        # closing nested tag\r\n                  )\r\n                  |\t\t\t\t\r\n                  <(?!/\\2\\s*>           # other tags with a different name\r\n                  )\r\n                )*", 6);
            string str5 = str4.Replace(@"\2", @"\3");
            string str6 = "\r\n            (?>\r\n                  (?>\r\n                    (?<=\\n)     # Starting after a blank line\r\n                    |           # or\r\n                    \\A\\n?       # the beginning of the doc\r\n                  )\r\n                  (             # save in $1\r\n\r\n                    # Match from `\\n<tag>` to `</tag>\\n`, handling nested tags \r\n                    # in between.\r\n                      \r\n                        [ ]{0,$less_than_tab}\r\n                        <($block_tags_b_re)   # start tag = $2\r\n                        $attr>                # attributes followed by > and \\n\r\n                        $content              # content, support nesting\r\n                        </\\2>                 # the matching end tag\r\n                        [ ]*                  # trailing spaces\r\n                        (?=\\n+|\\Z)            # followed by a newline or end of document\r\n\r\n                  | # Special version for tags of group a.\r\n\r\n                        [ ]{0,$less_than_tab}\r\n                        <($block_tags_a_re)   # start tag = $3\r\n                        $attr>[ ]*\\n          # attributes followed by >\r\n                        $content2             # content, support nesting\r\n                        </\\3>                 # the matching end tag\r\n                        [ ]*                  # trailing spaces\r\n                        (?=\\n+|\\Z)            # followed by a newline or end of document\r\n                      \r\n                  | # Special case just for <hr />. It was easier to make a special \r\n                    # case than to make the other regex more complicated.\r\n                  \r\n                        [ ]{0,$less_than_tab}\r\n                        <(hr)                 # start tag = $2\r\n                        $attr                 # attributes\r\n                        /?>                   # the matching end tag\r\n                        [ ]*\r\n                        (?=\\n{2,}|\\Z)         # followed by a blank line or end of document\r\n                  \r\n                  | # Special case for standalone HTML comments:\r\n                  \r\n                      [ ]{0,$less_than_tab}\r\n                      (?s:\r\n                        <!-- .*? -->\r\n                      )\r\n                      [ ]*\r\n                      (?=\\n{2,}|\\Z)            # followed by a blank line or end of document\r\n                  \r\n                  | # PHP and ASP-style processor instructions (<? and <%)\r\n                  \r\n                      [ ]{0,$less_than_tab}\r\n                      (?s:\r\n                        <([?%])                # $2\r\n                        .*?\r\n                        \\2>\r\n                      )\r\n                      [ ]*\r\n                      (?=\\n{2,}|\\Z)            # followed by a blank line or end of document\r\n                      \r\n                  )\r\n            )";
            int num = 3;
            return str6.Replace("$less_than_tab", num.ToString()).Replace("$block_tags_b_re", str2).Replace("$block_tags_a_re", newValue).Replace("$attr", str3).Replace("$content2", str5).Replace("$content", str4);
        }

        private static string GetHashKey(string s)
        {
            return ("\x001a" + Math.Abs(s.GetHashCode()).ToString() + "\x001a");
        }

        private static string GetNestedBracketsPattern()
        {
            if (_nestedBracketsPattern == null)
            {
                _nestedBracketsPattern = RepeatString("\r\n                    (?>              # Atomic matching\r\n                       [^\\[\\]]+      # Anything other than brackets\r\n                     |\r\n                       \\[\r\n                           ", 6) + RepeatString(" \\]\r\n                    )*", 6);
            }
            return _nestedBracketsPattern;
        }

        private static string GetNestedParensPattern()
        {
            if (_nestedParensPattern == null)
            {
                _nestedParensPattern = RepeatString("\r\n                    (?>              # Atomic matching\r\n                       [^()\\s]+      # Anything other than parens or whitespace\r\n                     |\r\n                       \\(\r\n                           ", 6) + RepeatString(" \\)\r\n                    )*", 6);
            }
            return _nestedParensPattern;
        }

        private string HashHTMLBlocks(string text)
        {
            return _blocksHtml.Replace(text, new MatchEvaluator(this.HtmlEvaluator));
        }

        private string HtmlEvaluator(Match match)
        {
            string s = match.Groups[1].Value;
            string hashKey = GetHashKey(s);
            this._htmlBlocks[hashKey] = s;
            return ("\n\n" + hashKey + "\n\n");
        }

        private string HyperlinkEvaluator(Match match)
        {
            string str = match.Groups[1].Value;
            return string.Format("<a href=\"{0}\">{0}</a>", str);
        }

        private string ImageInlineEvaluator(Match match)
        {
            string str = match.Groups[2].Value;
            string url = match.Groups[3].Value;
            string str3 = match.Groups[6].Value;
            str = str.Replace("\"", "&quot;");
            str3 = str3.Replace("\"", "&quot;");
            if (url.StartsWith("<") && url.EndsWith(">"))
            {
                url = url.Substring(1, url.Length - 2);
            }
            url = this.EncodeProblemUrlChars(url);
            url = this.EscapeBoldItalic(url);
            string str4 = string.Format("<img src=\"{0}\" alt=\"{1}\"", url, str);
            if (!string.IsNullOrEmpty(str3))
            {
                str3 = this.EscapeBoldItalic(str3);
                str4 = str4 + string.Format(" title=\"{0}\"", str3);
            }
            return (str4 + this._emptyElementSuffix);
        }

        private string ImageReferenceEvaluator(Match match)
        {
            string str = match.Groups[1].Value;
            string str2 = match.Groups[2].Value;
            string key = match.Groups[3].Value.ToLowerInvariant();
            if (key == "")
            {
                key = str2.ToLowerInvariant();
            }
            str2 = str2.Replace("\"", "&quot;");
            if (this._urls.ContainsKey(key))
            {
                string url = this._urls[key];
                url = this.EncodeProblemUrlChars(url);
                url = this.EscapeBoldItalic(url);
                string str4 = string.Format("<img src=\"{0}\" alt=\"{1}\"", url, str2);
                if (this._titles.ContainsKey(key))
                {
                    string s = this._titles[key];
                    s = this.EscapeBoldItalic(s);
                    str4 = str4 + string.Format(" title=\"{0}\"", s);
                }
                return (str4 + this._emptyElementSuffix);
            }
            return str;
        }

        private string LinkEvaluator(Match match)
        {
            string str = match.Groups[1].Value.ToLowerInvariant();
            this._urls[str] = this.EncodeAmpsAndAngles(match.Groups[2].Value);
            if ((match.Groups[3] != null) && (match.Groups[3].Length > 0))
            {
                this._titles[str] = match.Groups[3].Value.Replace("\"", "&quot;");
            }
            return "";
        }

        private string ListEvaluator(Match match)
        {
            string input = match.Groups[1].Value;
            string str2 = Regex.IsMatch(match.Groups[3].Value, "[*+-]") ? "ul" : "ol";
            input = Regex.Replace(input, @"\n{2,}", "\n\n\n");
            string str3 = this.ProcessListItems(input, (str2 == "ul") ? "[*+-]" : @"\d+[.]");
            return string.Format("<{0}>\n{1}</{0}>\n", str2, str3);
        }

        private string ListItemEvaluator(Match match)
        {
            string input = match.Groups[4].Value;
            if (!string.IsNullOrEmpty(match.Groups[1].Value) || Regex.IsMatch(input, @"\n{2,}"))
            {
                input = this.RunBlockGamut(this.Outdent(input) + "\n");
            }
            else
            {
                input = this.DoLists(this.Outdent(input)).TrimEnd(new char[] { '\n' });
                input = this.RunSpanGamut(input);
            }
            return string.Format("<li>{0}</li>\n", input);
        }

        private string Normalize(string text)
        {
            StringBuilder builder = new StringBuilder(text.Length);
            StringBuilder builder2 = new StringBuilder();
            bool flag = false;
            for (int i = 0; i < text.Length; i++)
            {
                int num2;
                int num3;
                switch (text[i])
                {
                    case '\t':
                        num2 = 4 - (builder2.Length % 4);
                        num3 = 0;
                        goto Label_00C3;

                    case '\n':
                    {
                        if (flag)
                        {
                            builder.Append(builder2);
                        }
                        builder.Append('\n');
                        builder2.Length = 0;
                        flag = false;
                        continue;
                    }
                    case '\r':
                    {
                        if ((i < (text.Length - 1)) && (text[i + 1] != '\n'))
                        {
                            if (flag)
                            {
                                builder.Append(builder2);
                            }
                            builder.Append('\n');
                            builder2.Length = 0;
                            flag = false;
                        }
                        continue;
                    }
                    case '\x001a':
                    {
                        continue;
                    }
                    default:
                        goto Label_00CB;
                }
            Label_00B4:
                builder2.Append(' ');
                num3++;
            Label_00C3:
                if (num3 < num2)
                {
                    goto Label_00B4;
                }
                continue;
            Label_00CB:
                if (!flag && (text[i] != ' '))
                {
                    flag = true;
                }
                builder2.Append(text[i]);
            }
            if (flag)
            {
                builder.Append(builder2);
            }
            builder.Append('\n');
            return builder.Append("\n\n").ToString();
        }

        private string Outdent(string block)
        {
            return _outDent.Replace(block, "");
        }

        private string ProcessListItems(string list, string marker)
        {
            this._listLevel++;
            list = Regex.Replace(list, @"\n{2,}\z", "\n");
            string pattern = string.Format("(\\n)?                      # leading line = $1\r\n                (^[ ]*)                    # leading whitespace = $2\r\n                ({0}) [ ]+                 # list marker = $3\r\n                ((?s:.+?)                  # list item text = $4\r\n                (\\n{{1,2}}))      \r\n                (?= \\n* (\\z | \\2 ({0}) [ ]+))", marker);
            list = Regex.Replace(list, pattern, new MatchEvaluator(this.ListItemEvaluator), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            this._listLevel--;
            return list;
        }

        private static string RepeatString(string text, int count)
        {
            StringBuilder builder = new StringBuilder(text.Length * count);
            for (int i = 0; i < count; i++)
            {
                builder.Append(text);
            }
            return builder.ToString();
        }

        private string RunBlockGamut(string text)
        {
            text = this.DoHeaders(text);
            text = this.DoHorizontalRules(text);
            text = this.DoLists(text);
            text = this.DoCodeBlocks(text);
            text = this.DoBlockQuotes(text);
            text = this.HashHTMLBlocks(text);
            text = this.FormParagraphs(text);
            return text;
        }

        private string RunSpanGamut(string text)
        {
            text = this.DoCodeSpans(text);
            text = this.EscapeSpecialCharsWithinTagAttributes(text);
            text = this.EscapeBackslashes(text);
            text = this.DoImages(text);
            text = this.DoAnchors(text);
            text = this.DoAutoLinks(text);
            text = this.EncodeAmpsAndAngles(text);
            text = this.DoItalicsAndBold(text);
            text = this.DoHardBreaks(text);
            return text;
        }

        private string SetextHeaderEvaluator(Match match)
        {
            string text = match.Groups[1].Value;
            int num = match.Groups[2].Value.StartsWith("=") ? 1 : 2;
            return string.Format("<h{1}>{0}</h{1}>\n\n", this.RunSpanGamut(text), num);
        }

        private void Setup()
        {
            this._urls.Clear();
            this._titles.Clear();
            this._htmlBlocks.Clear();
            this._listLevel = 0;
        }

        private string StripLinkDefinitions(string text)
        {
            return _linkDef.Replace(text, new MatchEvaluator(this.LinkEvaluator));
        }

        private List<Token> TokenizeHTML(string text)
        {
            int startIndex = 0;
            int index = 0;
            List<Token> list = new List<Token>();
            foreach (Match match in _htmlTokens.Matches(text))
            {
                index = match.Index;
                if (startIndex < index)
                {
                    list.Add(new Token(TokenType.Text, text.Substring(startIndex, index - startIndex)));
                }
                list.Add(new Token(TokenType.Tag, match.Value));
                startIndex = index + match.Length;
            }
            if (startIndex < text.Length)
            {
                list.Add(new Token(TokenType.Text, text.Substring(startIndex, text.Length - startIndex)));
            }
            return list;
        }

        public string Transform(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            this.Setup();
            text = this.Normalize(text);
            text = this.HashHTMLBlocks(text);
            text = this.StripLinkDefinitions(text);
            text = this.RunBlockGamut(text);
            text = this.Unescape(text);
            this.Cleanup();
            return (text + "\n");
        }

        private string Unescape(string s)
        {
            return _unescapes.Replace(s, new MatchEvaluator(this.UnescapeEvaluator));
        }

        private string UnescapeEvaluator(Match match)
        {
            return _invertedEscapeTable[match.Value];
        }

        public bool AutoHyperlink
        {
            get
            {
                return this._autoHyperlink;
            }
            set
            {
                this._autoHyperlink = value;
            }
        }

        public bool AutoNewLines
        {
            get
            {
                return this._autoNewlines;
            }
            set
            {
                this._autoNewlines = value;
            }
        }

        public string EmptyElementSuffix
        {
            get
            {
                return this._emptyElementSuffix;
            }
            set
            {
                this._emptyElementSuffix = value;
            }
        }

        public bool EncodeProblemUrlCharacters
        {
            get
            {
                return this._encodeProblemUrlCharacters;
            }
            set
            {
                this._encodeProblemUrlCharacters = value;
            }
        }

        public bool LinkEmails
        {
            get
            {
                return this._linkEmails;
            }
            set
            {
                this._linkEmails = value;
            }
        }

        public bool StrictBoldItalic
        {
            get
            {
                return this._strictBoldItalic;
            }
            set
            {
                this._strictBoldItalic = value;
            }
        }

        public string Version
        {
            get
            {
                return "1.12";
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Token
        {
            public Markdown.TokenType Type;
            public string Value;
            public Token(Markdown.TokenType type, string value)
            {
                this.Type = type;
                this.Value = value;
            }
        }

        private enum TokenType
        {
            Text,
            Tag
        }
    }
}

