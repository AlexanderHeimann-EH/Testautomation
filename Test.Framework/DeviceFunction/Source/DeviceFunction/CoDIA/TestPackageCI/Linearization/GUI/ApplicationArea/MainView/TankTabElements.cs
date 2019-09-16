// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TankTabElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class TankTabElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Linearization.GUI.ApplicationArea.MainView
{
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class TankTabElements.
    /// </summary>
    public class TankTabElements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly MainViewElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TankTabElements"/> class. 
        /// Initializes a new instance of the <see cref="MainViewElements"/> class.
        /// </summary>
        public TankTabElements()
        {
            this.repository = MainViewElementsRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Common

        /// <summary>
        /// Gets the calculate table button 
        /// </summary>
        public Element CalculateTableButton
        {
            get
            {
                Element element;
                RepoItemInfo calculateTableInfo = this.repository.Tank.ButtonCalculateTableInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + calculateTableInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the calculation steps text box
        /// </summary>
        public Element CalculationStepsTextbox
        {
            get
            {
                Element element;
                RepoItemInfo calculationStepsInfo = this.repository.Tank.TextBoxCalculationStepsInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + calculationStepsInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the levels radio button
        /// </summary>
        public Element LevelsRadioButton
        {
            get
            {
                Element element;
                RepoItemInfo levelsInfo = this.repository.Tank.RadioButtonLevelsInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + levelsInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the start volume radio button
        /// </summary>
        public Element StartVolumeRadioButton
        {
            get
            {
                Element element;
                RepoItemInfo startVolumeInfo = this.repository.Tank.RadioButtonStartVolumeInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + startVolumeInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the tank form selection combo box 
        /// </summary>
        public Element TankFormSelectionCombobox
        {
            get
            {
                Element element;
                RepoItemInfo tankformSelectionInfo = this.repository.Tank.ComboBoxTankFormSelectionInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + tankformSelectionInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion

        #region HorizontalCylindricalTankStandard

        /// <summary>
        /// Gets the ComboBox end type left.
        /// </summary>
        /// <value>The ComboBox end type left.</value>
        public Element HorizontalCylindricalTankStandardComboBoxEndTypeLeft
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.ComboBoxEndTypeLeftInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBox end type right.
        /// </summary>
        /// <value>The ComboBox end type right.</value>
        public Element HorizontalCylindricalTankStandardComboBoxEndTypeRight
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.ComboBoxEndTypeRightInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standard edit field angle.
        /// </summary>
        /// <value>The horizontal cylindrical tank standard edit field angle.</value>
        public Element HorizontalCylindricalTankStandardEditFieldAngle
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.EditFieldAngleInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standard edit field change position.
        /// </summary>
        /// <value>The horizontal cylindrical tank standard edit field change position.</value>
        public Element HorizontalCylindricalTankStandardEditFieldChangePosition
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.EditFieldChangePositionInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standard edit field diameter.
        /// </summary>
        /// <value>The horizontal cylindrical tank standard edit field diameter.</value>
        public Element HorizontalCylindricalTankStandardEditFieldDiameter
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.EditFieldDiameterInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standard edit field empty.
        /// </summary>
        /// <value>The horizontal cylindrical tank standard edit field empty.</value>
        public Element HorizontalCylindricalTankStandardEditFieldEmpty
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.EditFieldEmptyInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standard edit field full.
        /// </summary>
        /// <value>The horizontal cylindrical tank standard edit field full.</value>
        public Element HorizontalCylindricalTankStandardEditFieldFull
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.EditFieldFullInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the height of the horizontal cylindrical tank standard edit field.
        /// </summary>
        /// <value>The height of the horizontal cylindrical tank standard edit field.</value>
        public Element HorizontalCylindricalTankStandardEditFieldHeight
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.EditFieldHeightInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the length of the horizontal cylindrical tank standard edit field.
        /// </summary>
        /// <value>The length of the horizontal cylindrical tank standard edit field.</value>
        public Element HorizontalCylindricalTankStandardEditFieldLength
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.EditFieldLengthInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standard edit field wall thickness.
        /// </summary>
        /// <value>The horizontal cylindrical tank standard edit field wall thickness.</value>
        public Element HorizontalCylindricalTankStandardEditFieldWallThickness
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStandard.EditFieldWallThicknessInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion

        #region HorizontalCylindricalTankStanding

        /// <summary>
        /// Gets the horizontal cylindrical tank standing ComboBox bottom.
        /// </summary>
        /// <value>The horizontal cylindrical tank standing ComboBox bottom.</value>
        public Element HorizontalCylindricalTankStandingComboBoxBottomType
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.ComboBoxBottomTypeInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the type of the horizontal cylindrical tank standing ComboBox ceiling.
        /// </summary>
        /// <value>The type of the horizontal cylindrical tank standing ComboBox ceiling.</value>
        public Element HorizontalCylindricalTankStandingComboBoxCeilingType
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.ComboBoxCeilingTypeInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the height of the horizontal cylindrical tank standing edit field bottom.
        /// </summary>
        /// <value>The height of the horizontal cylindrical tank standing edit field bottom.</value>
        public Element HorizontalCylindricalTankStandingEditFieldBottomHeight
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldBottomHeightInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the width of the horizontal cylindrical tank standing edit field bottom.
        /// </summary>
        /// <value>The width of the horizontal cylindrical tank standing edit field bottom.</value>
        public Element HorizontalCylindricalTankStandingEditFieldBottomWidth
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldBottomWidthInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the height of the horizontal cylindrical tank standing edit field ceiling.
        /// </summary>
        /// <value>The height of the horizontal cylindrical tank standing edit field ceiling.</value>
        public Element HorizontalCylindricalTankStandingEditFieldCeilingHeight
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldCeilingHeightInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the width of the horizontal cylindrical tank standing edit field ceiling.
        /// </summary>
        /// <value>The width of the horizontal cylindrical tank standing edit field ceiling.</value>
        public Element HorizontalCylindricalTankStandingEditFieldCeilingWidth
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldCeilingWidthInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standing edit field empty.
        /// </summary>
        /// <value>The horizontal cylindrical tank standing edit field empty.</value>
        public Element HorizontalCylindricalTankStandingEditFieldEmpty
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldEmptyInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standing edit field full.
        /// </summary>
        /// <value>The horizontal cylindrical tank standing edit field full.</value>
        public Element HorizontalCylindricalTankStandingEditFieldFull
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldFullInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the height of the horizontal cylindrical tank standing edit field.
        /// </summary>
        /// <value>The height of the horizontal cylindrical tank standing edit field.</value>
        public Element HorizontalCylindricalTankStandingEditFieldHeight
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldHeightInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standing edit field internal diameter.
        /// </summary>
        /// <value>The horizontal cylindrical tank standing edit field internal diameter.</value>
        public Element HorizontalCylindricalTankStandingEditFieldInternalDiameter
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldInternalDiameterInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the length of the horizontal cylindrical tank standing edit field.
        /// </summary>
        /// <value>The length of the horizontal cylindrical tank standing edit field.</value>
        public Element HorizontalCylindricalTankStandingEditFieldLength
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldLengthInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standing edit field wall thickness.
        /// </summary>
        /// <value>The horizontal cylindrical tank standing edit field wall thickness.</value>
        public Element HorizontalCylindricalTankStandingEditFieldWallThickness
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.HorizontalCylindricalTankStanding.EditFieldWallThicknessInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion

        #region ModularTankCircular

        /// <summary>
        /// Gets the modular tank circular edit field empty.
        /// </summary>
        /// <value>The modular tank circular edit field empty.</value>
        public Element ModularTankCircularEditFieldEmpty
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.ModularTankCircular.EditFieldEmptyInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the modular tank circular edit field full.
        /// </summary>
        /// <value>The modular tank circular edit field full.</value>
        public Element ModularTankCircularEditFieldFull
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.ModularTankCircular.EditFieldFullInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the height of the modular tank circular edit field.
        /// </summary>
        /// <value>The height of the modular tank circular edit field.</value>
        public Element ModularTankCircularEditFieldHeight
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.ModularTankCircular.EditFieldHeightInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion

        #region ModularTankStandard

        /// <summary>
        /// Gets the modular tank standard ComboBox view.
        /// </summary>
        /// <value>The modular tank standard ComboBox view.</value>
        public Element ModularTankStandardComboBoxView
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.ModularTankStandard.ComboBoxViewInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the modular tank standard edit field empty.
        /// </summary>
        /// <value>The modular tank standard edit field empty.</value>
        public Element ModularTankStandardEditFieldEmpty
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.ModularTankStandard.EditFieldEmptyInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the modular tank standard edit field full.
        /// </summary>
        /// <value>The modular tank standard edit field full.</value>
        public Element ModularTankStandardEditFieldFull
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.ModularTankStandard.EditFieldFullInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the height of the modular tank standard edit field.
        /// </summary>
        /// <value>The height of the modular tank standard edit field.</value>
        public Element ModularTankStandardEditFieldHeight
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.ModularTankStandard.EditFieldHeightInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion

        #region SphericalTankHydrostatic

        /// <summary>
        /// Gets the spherical tank hydrostatic.
        /// </summary>
        /// <value>The spherical tank hydrostatic.</value>
        public Element SphericalTankHydrostatic
        {
            get
            {
                ////Element element;
                ////RepoItemInfo itemInfo = this.repository.Tank.SphericalTankHydrostatic.
                ////Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                ////return element;
                return null;
            }
        }

        #endregion

        #region SphericalTankStandard

        /// <summary>
        /// Gets the spherical tank standard edit field diameter.
        /// </summary>
        /// <value>The spherical tank standard edit field diameter.</value>
        public Element SphericalTankStandardEditFieldDiameter
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.SphericalTankStandard.EditFieldDiameterInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the spherical tank standard edit field empty.
        /// </summary>
        /// <value>The spherical tank standard edit field empty.</value>
        public Element SphericalTankStandardEditFieldEmpty
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.SphericalTankStandard.EditFieldEmptyInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the spherical tank standard edit field full.
        /// </summary>
        /// <value>The spherical tank standard edit field full.</value>
        public Element SphericalTankStandardEditFieldFull
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.SphericalTankStandard.EditFieldFullInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the height of the spherical tank standard edit field.
        /// </summary>
        /// <value>The height of the spherical tank standard edit field.</value>
        public Element SphericalTankStandardEditFieldHeight
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Tank.SphericalTankStandard.EditFieldHeightInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion
    }
}