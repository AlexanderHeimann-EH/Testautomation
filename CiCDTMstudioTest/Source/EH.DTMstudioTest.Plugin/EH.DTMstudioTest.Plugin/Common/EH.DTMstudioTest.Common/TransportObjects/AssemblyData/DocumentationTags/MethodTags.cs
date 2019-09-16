// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodTags.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class MethodDocumentation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.DocumentationTags
{
    using System.Collections;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;

    /// <summary>
    /// Class MethodDocumentation.
    /// </summary>
    public class MethodTags
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodTags"/> class.
        /// </summary>
        /// <param name="methodName">
        /// Name of the method.
        /// </param>
        public MethodTags(string methodName)
        {
            this.MethodName = methodName;
            this.Summary = new SummaryTag();
            this.Parameter = new ParamTags();
            this.Suites = new SuiteTags();
            this.Return = new ReturnTag();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        /// <value>The name of the method.</value>
        public string MethodName { get; private set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public ParamTags Parameter { get; set; }

        /// <summary>
        /// Gets or sets the return.
        /// </summary>
        /// <value>The return.</value>
        public ReturnTag Return { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public SummaryTag Summary { get; set; }

        /// <summary>
        /// Gets or sets the test suites.
        /// </summary>
        public SuiteTags Suites { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the get documentation text.
        /// </summary>
        /// <value>
        /// The get documentation text.
        /// </value>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDocumentationText()
        {
            if (this.Summary.DocumentationTagFound)
            {
                var result = this.Summary.GetDescriptionText();
                result += this.Parameter.GetDescriptionText();

                result += this.Return.GetDescriptionText();

                return result.Trim();
            }

            return string.Empty;
        }

        #endregion
    }
}