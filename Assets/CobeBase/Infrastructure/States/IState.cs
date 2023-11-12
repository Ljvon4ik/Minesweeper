using Cysharp.Threading.Tasks;

namespace CobeBase.Infrastructure.States
{
    public interface IState
    {
        public void Enter();
        public void Exit();
    }
}

