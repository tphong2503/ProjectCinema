using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProjectCinema.UI
{
    /// <summary>
    /// Base form class that inherits from MaterialForm.
    /// Includes workaround for Visual Studio Designer.
    /// </summary>
    [DesignerCategory("Form")]
    public class MaterialBaseForm : MaterialForm
    {
        protected MaterialSkinManager materialSkinManager;

        public MaterialBaseForm() : base()
        {
            // Only initialize MaterialSkinManager at runtime, not in Designer
            if (!IsDesignMode())
            {
                InitializeMaterialSkin();
            }
        }

        /// <summary>
        /// Check if running in Design mode (VS Designer)
        /// </summary>
        protected bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime 
                   || DesignMode 
                   || (Process.GetCurrentProcess().ProcessName == "devenv");
        }

        /// <summary>
        /// Initialize MaterialSkinManager with Dark theme and Cinema color scheme
        /// </summary>
        protected virtual void InitializeMaterialSkin()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey900,    // Primary color
                Primary.BlueGrey800,    // Dark primary color  
                Primary.Blue400,        // Light primary color
                Accent.LightBlue200,    // Accent color
                TextShade.WHITE         // Text shade
            );
        }

        /// <summary>
        /// Change the color scheme of the form
        /// </summary>
        protected void SetColorScheme(Primary primary, Primary darkPrimary, Primary lightPrimary, Accent accent)
        {
            if (materialSkinManager != null)
            {
                materialSkinManager.ColorScheme = new ColorScheme(
                    primary, darkPrimary, lightPrimary, accent, TextShade.WHITE
                );
            }
        }

        /// <summary>
        /// Toggle between Light and Dark theme
        /// </summary>
        protected void ToggleTheme()
        {
            if (materialSkinManager != null)
            {
                materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK
                    ? MaterialSkinManager.Themes.LIGHT
                    : MaterialSkinManager.Themes.DARK;
            }
        }
    }
}
