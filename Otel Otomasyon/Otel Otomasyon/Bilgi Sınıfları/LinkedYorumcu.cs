using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyon
{
    public class LinkedYorumcu
    {
        public YorumcuDugumu head;
        public int size;

        public void YorumEkle(Yorumcu yorumYapan)
        {

            //Eski sonuncu node, Head'den başlanarak set ediliyor
            YorumcuDugumu oldLast = head;


            if (head == null)
            {
                YorumcuDugumu tmpHead = new YorumcuDugumu
                {
                   yorumcuBilgisi  = yorumYapan
                };

                head = tmpHead;
            }
            else
            {
                //Yeni sonuncu node yaratılıyor
                YorumcuDugumu newLast = new YorumcuDugumu
                {
                   yorumcuBilgisi  = yorumYapan
                };

                //Eski sonuncu node bulunuyor
                //Tail olsaydı sonuncuyu bulmaya gerek yoktu.
                while (oldLast != null)
                {
                    if (oldLast.sonraki != null)
                        oldLast = oldLast.sonraki;
                    else
                        break;
                }

                //Eski sonuncu node referansı artık yeni sonuncu node'u gösteriyor
                oldLast.sonraki = newLast;

                //Bağlı listedeki eleman sayısı bir arttı
                size++;
            }
        }
    }
}
