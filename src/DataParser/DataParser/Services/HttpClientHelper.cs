namespace DataParser.Services
{
	public static class HttpClientHelper
	{
		public static void ConfigureClient(HttpClient client, string referer)
		{
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Add("referer", referer);
			client.DefaultRequestHeaders.Add("authority", "api.bo3.gg");
			client.DefaultRequestHeaders.Add("accept", "application/json, text/plain, */*");
			client.DefaultRequestHeaders.Add("accept-language", "ru,en;q=0.9");
			client.DefaultRequestHeaders.Add("origin", "https://bo3.gg");
			client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 YaBrowser/24.1.0.0 Safari/537.36");
			client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
			client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
			client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
			client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
			client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"YaBrowser\";v=\"24.1\", \"Yowser\";v=\"2.5\"");
			client.DefaultRequestHeaders.Add("sec-fetch-site", "same-site");
		}
	}
}
