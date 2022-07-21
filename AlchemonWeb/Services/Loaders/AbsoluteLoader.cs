using System;
namespace AlchemonWeb.Services.Loaders
{
	public class AbsoluteLoader : ILoader
	{
		private static AbsoluteLoader? _instance;
        private Queue<ILoader> _loaders = new();
		private AbsoluteLoader() 
		{
		}
		public static AbsoluteLoader getInstance()
        {
			if (_instance is null)
				_instance = new AbsoluteLoader();
			return _instance;
        }

		public void PutInQueue(ILoader loader)
        {
			if (!_loaders.Contains(loader))
				_loaders.Enqueue(loader);
        }
        public void PutInQueue(List<ILoader> loaders)
        {
			foreach (var l in loaders) PutInQueue(l);
        }

        public List<string> Load()
        {
			ILoader? loader;
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

