using System;
using System.Windows.Forms;
using HospitalManagementSystem.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace HospitalManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ── Bootstrap MaterialSkin2 ──────────────────────
            var skinManager = MaterialSkinManager.Instance;

            skinManager.EnforceBackcolorOnAllComponents = true;
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Hospital Light Theme: Clinical Blue primary, Soft Teal accent
            skinManager.ColorScheme = new ColorScheme(
                Primary.Blue700,    // Primary header color
                Primary.Blue800,    // Darker status bar
                Primary.Blue200,    // Lighter backgrounds/dividers
                Accent.Teal700,     // Stronger teal for better contrast on white
                TextShade.WHITE     // Text color for the primary bars
            );

            // ── Launch Login Form ────────────────────────────
            Application.Run(new LoginForm());
        }
    }
}