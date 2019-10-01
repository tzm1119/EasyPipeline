using System;
using System.Threading.Tasks;
namespace EasyPipeline
{
    public abstract class Handler<TContext>
    {
        private Handler<TContext> _nextHandler;
        private Handler<TContext> _prevHandler;
        private bool _isRoot;


        public Handler<TContext> SetRoot()
        {
            _isRoot = true;
            return this;
        }

        public Handler<TContext> Next(Handler<TContext> handler)
        {
            _nextHandler = handler;
            _nextHandler._prevHandler = this;
            return _nextHandler;
        }

        public async Task Run(TContext data)
        {
            if (_isRoot)
                await Handle(data);
            else
            {
                _prevHandler?.Run(data);
            }
        }


        protected virtual async Task Handle(TContext data)
        {
            //call next
            if (_nextHandler!=null)
            {
                 await _nextHandler?.Handle(data);
            }
           
        }
    }
}
