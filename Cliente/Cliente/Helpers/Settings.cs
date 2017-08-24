// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Cliente.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;
        
	    private const string ApiKey = "http://tcc.devsistemas.com.br/api/";
	    private static readonly string ApiDefault = "http://tcc.devsistemas.com.br/api/";

	    private const string UserIdKey = "user_id";
	    private static readonly string UserIdDefault = string.Empty;

	    private const string UserSubscribeKey = "user_subscribe";
	    private static readonly string UserSubscribeDefault = string.Empty;

	    private const string UserNomeKey = "user_nome";
	    private static readonly string UserNomeDefault = string.Empty;

	    public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserIdSettings);

        #endregion


        public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

	    public static string ApiSettings
	    {
	        get => AppSettings.GetValueOrDefault(ApiKey, ApiDefault);
	        set => AppSettings.AddOrUpdateValue(ApiKey, value);
	    }

	    public static string UserIdSettings
	    {
	        get => AppSettings.GetValueOrDefault(UserIdKey, UserIdDefault);
	        set => AppSettings.AddOrUpdateValue(UserIdKey, value);
	    }

	    public static string UserNomeSettings
	    {
	        get => AppSettings.GetValueOrDefault(UserNomeKey, UserNomeDefault);
	        set => AppSettings.AddOrUpdateValue(UserNomeKey, value);
	    }

	    public static string UserSubscribeSettings
	    {
	        get => AppSettings.GetValueOrDefault(UserSubscribeKey, UserSubscribeDefault);
	        set => AppSettings.AddOrUpdateValue(UserSubscribeKey, value);
	    }

    }
}