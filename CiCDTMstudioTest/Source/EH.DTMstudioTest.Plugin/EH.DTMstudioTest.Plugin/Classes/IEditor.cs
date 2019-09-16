// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditor.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   IEditor is the automation interface for EditorDocument.
//   The implementation of the methods is just a wrapper over the rich
//   edit control's object model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System.Runtime.InteropServices;

    using tom;

    /// <summary>
    /// IEditor is the automation interface for EditorDocument.
    /// The implementation of the methods is just a wrapper over the rich
    /// edit control's object model.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IEditor
    {
        /// <summary>
        /// Gets or sets the default tab stop.
        /// </summary>
        float DefaultTabStop { get; set; }

        /// <summary>
        /// Gets the range.
        /// </summary>
        ITextRange Range { get; }

        /// <summary>
        /// Gets the selection.
        /// </summary>
        ITextSelection Selection { get; }

        /// <summary>
        /// Gets or sets the selection properties.
        /// </summary>
        int SelectionProperties { get; set; }

        /// <summary>
        /// The find text.
        /// </summary>
        /// <param name="textToFind">
        /// The text to find.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int FindText(string textToFind);

        /// <summary>
        /// The set text.
        /// </summary>
        /// <param name="textToSet">
        /// The text to set.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int SetText(string textToSet);

        /// <summary>
        /// The type text.
        /// </summary>
        /// <param name="textToType">
        /// The text to type.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int TypeText(string textToType);

        /// <summary>
        /// The cut.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Cut();

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Copy();

        /// <summary>
        /// The paste.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Paste();

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Delete(long unit, long count);

        /// <summary>
        /// The move up.
        /// </summary>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <param name="extend">
        /// The extend.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int MoveUp(int unit, int count, int extend);

        /// <summary>
        /// The move down.
        /// </summary>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <param name="extend">
        /// The extend.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int MoveDown(int unit, int count, int extend);

        /// <summary>
        /// The move left.
        /// </summary>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <param name="extend">
        /// The extend.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int MoveLeft(int unit, int count, int extend);

        /// <summary>
        /// The move right.
        /// </summary>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <param name="extend">
        /// The extend.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int MoveRight(int unit, int count, int extend);

        /// <summary>
        /// The end key.
        /// </summary>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <param name="extend">
        /// The extend.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int EndKey(int unit, int extend);

        /// <summary>
        /// The home key.
        /// </summary>
        /// <param name="unit">
        /// The unit.
        /// </param>
        /// <param name="extend">
        /// The extend.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int HomeKey(int unit, int extend);
    }
}