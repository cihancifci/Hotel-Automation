using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyon
{
   public class PuanliHeap
    {

        HeapDugumu[] heapArray;
        int maxSize;
        int currentSize;

        public PuanliHeap(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            currentSize = 0;
            heapArray = new HeapDugumu[maxSize];
        }

        public bool Insert(Otel ekleOtel)
        {
            if (currentSize == maxSize)
                return false;

            HeapDugumu newHeapDugumu = new HeapDugumu(ekleOtel);
            heapArray[currentSize] = newHeapDugumu;
            MoveToUp(currentSize++);
            return true;

        }

        public bool IsEmpty()
        {
            return currentSize == 0;
        }

        public void MoveToDown(int index)
        {
            int largerChild;
            HeapDugumu top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                //Find larger child
                if (rightChild < currentSize && heapArray[leftChild].otel.otelPuani < heapArray[rightChild].otel.otelPuani)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (top.otel.otelPuani >= heapArray[largerChild].otel.otelPuani)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }

        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArray[index];
            while (index > 0 && heapArray[parent].otel.otelPuani < bottom.otel.otelPuani)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }

        public HeapDugumu RemoveMax()
        {
            HeapDugumu root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            MoveToDown(0);
            return root;
        }

        public List<Otel> SiraliVeriAl()
        {
            List<Otel> oteller = new List<Otel>();
            //Ağaçtaki maksimum elemanı al ve yeni diziye ekle
            while (!IsEmpty())
                oteller.Add(RemoveMax().otel);
            return oteller;
        }
    }
}
