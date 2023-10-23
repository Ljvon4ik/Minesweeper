using Cysharp.Threading.Tasks;

namespace CobeBase.Infrastructure.States
{
    public interface IState
    {
        public UniTask Enter();
        public void Exit();
    }
}

