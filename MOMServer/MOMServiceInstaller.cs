using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;



namespace MOM
{
    /// <summary>
    /// Summary description for MyNewServiceInstaller1.
    /// </summary>
    [RunInstaller(true)]
    public class MyNewServiceInstaller : System.Configuration.Install.Installer
    {
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller MOMService;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MyNewServiceInstaller()
        {
            // This call is required by the Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitComponent call
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.MOMService = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // BuilderServiceDEV
            // 
            this.MOMService.Description = "Master of Magic Server Service";
            this.MOMService.DisplayName = "Master of Magic Server";
            this.MOMService.ServiceName = "Master of Magic Server";
            this.MOMService.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.MOMService.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            // 
            // MyNewServiceInstaller1
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.MOMService});

        }
        #endregion

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
