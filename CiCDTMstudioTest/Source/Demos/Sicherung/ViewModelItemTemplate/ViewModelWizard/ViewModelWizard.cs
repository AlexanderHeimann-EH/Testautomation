
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;

namespace ViewModelWizard
{
    public class ViewModelWizard : IWizard
    {
        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(EnvDTE.Project project)
        {
        }

        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject, 
            Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            //  Create the form.
            var form = new NewViewModelForm();

            //  Show the form.
            form.ShowDialog();

            //  Add the options to the replacementsDictionary.
            replacementsDictionary.Add("$IncludeExample$", form.IncludeExample ? "1" : "0");
            replacementsDictionary.Add("$PropertyName$", form.PropertyName);
            replacementsDictionary.Add("$PropertyType$", form.PropertyType);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
