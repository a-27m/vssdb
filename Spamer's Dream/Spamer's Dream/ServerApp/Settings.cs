using System.Windows.Forms;
namespace ServerApp.Properties {
	internal sealed partial class Settings {
		public Settings() {
			this.SettingChanging += this.SettingChangingEventHandler;
			//this.SettingsSaving += this.SettingsSavingEventHandler;
		}

		private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
			if ( e.SettingName != "RobotUdpPort" )
				return;

			int port = (int)( e.NewValue );
			if ( ( port < 1 ) || ( port > 65535 ) )
				e.Cancel = true;
		}
	}
}
