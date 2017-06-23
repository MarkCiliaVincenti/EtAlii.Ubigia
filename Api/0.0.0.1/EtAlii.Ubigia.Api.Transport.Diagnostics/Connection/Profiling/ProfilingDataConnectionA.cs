//namespace EtAlii.Ubigia.Api.Transport.Diagnostics
//{
//    using System.Threading.Tasks;
//    using EtAlii.Ubigia.Api.Diagnostics.Profiling;
//    using EtAlii.Ubigia.Api.Transport;

//    public class ProfilingDataConnection : IProfilingDataConnection 
//    {
//        public IProfiler Profiler { get; }

//        public Storage Storage => _decoree.Storage;
//        public Account Account => _decoree.Account;
//        public Space Space => _decoree.Space;
//        public IEntryContext Entries => _decoree.Entries;
//        public IRootContext Roots => _decoree.Roots;
//        public IContentContext Content => _decoree.Content;
//        public IPropertyContext Properties => _decoree.Properties;
//        public bool IsConnected => _decoree.IsConnected;
//        public IDataConnectionConfiguration Configuration => _decoree.Configuration;

//        private readonly IDataConnection _decoree;

//        public ProfilingDataConnection(IDataConnection decoree, IProfiler profiler)
//        {
//            _decoree = decoree;
//            Profiler = profiler;
//        }

//        public async Task Open()
//        {
//            await _decoree.Open();
//        }

//        public async Task Close()
//        {
//            await _decoree.Close();
//        }
//    }
//}