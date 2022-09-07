using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

    class PayFacade
    {
        private AccountSystem account = new AccountSystem();

        private CardSystem card = new CardSystem();

        private PaySyestem PaySyestem = new PaySyestem();

        public string CreateOrder(string userName,int cardId,int cardCount,int areaId)
        {
            int userId = account.GetUserIdByUserName(userName);

            if (userId==0)
            {
                return string.Empty;
            }

            if (!account.UserIsActived(userId,areaId))
            {
                return string.Empty;
            }

            if (!card.CardHasStock(cardId,cardCount))
            {
                return string.Empty;
            }

            return PaySyestem.CreateOrder(userId,cardId,cardCount);





        }


    }

   
    class AccountSystem
    {
        public bool UserIsActived(int userId,int areaId)
        {
            return true;
        }

        public int GetUserIdByUserName(string userName)
        {
            return 123;
        }
    }

    class CardSystem
    {
        public bool CardHasStock(int cardId,int cardCount)
        {
            return true;
        }
    }


    class PaySyestem
    {
        public string CreateOrder(int userId,int cardId,int cardCount)
        {
            return "0000000001";
        }
    }



}
