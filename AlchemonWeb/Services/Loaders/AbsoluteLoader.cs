using System;
namespace AlchemonWeb.Services.Loaders
{
	public class AbsoluteLoader : ILoader
	{
		private static AbsoluteLoader instance;
        private Queue<ILoader> _loaders;
		private AbsoluteLoader()
		{
		}
		public static AbsoluteLoader getInstance()
        {
			if (instance is null)
				instance = new AbsoluteLoader();
			return instance;
        }

		public void GetInQueue(ILoader loader)
        {
			if (!_loaders.Contains(loader))
				_loaders.Enqueue(loader);
        }
        public void GetInQueue(List<ILoader> loaders)
        {
			foreach (var l in loaders) GetInQueue(l);
        }

        public List<string> Load()
        {
			ILoader loader;
			List<string> response = new List<string> { "АБСОЛЮТНАЯ ЗАГРУЗКА:\n"}; 
			while(_loaders.TryDequeue(out loader))
            {
				response.AddRange(loader.Load());
				response.Add(" ");
            }
			return response;
        }

    }
}

