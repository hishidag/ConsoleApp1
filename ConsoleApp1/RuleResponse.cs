using System.Diagnostics.Contracts;

namespace ConsoleApp1
{
    public class RuleResponse
    {
        private string _info;

        public string Info { 
            get
            {
                Contract.Requires<NotSetInfoException>(_info != null, "レスポンスが処理されていません。");
                return _info; 
            }
            private set => _info = value ; 
        }

        public RuleResponse(string info)
        {
            Info = info;
        }
    }

}
