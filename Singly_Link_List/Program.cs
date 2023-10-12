using System;

namespace Singly_Link_List
{
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }

    class List
    {
        Node START;
        public List()
        {
            START = null;

        }
        public void addNode()
        {
            int rollNo;
            string nm;
            Console.Write("\n Masuk ke roll rumber siswa: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Masukkan nama siswa: ");
            nm = Console.ReadLine();

            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;

            if (START == null || rollNo <= START.rollNumber)
            {
                if ((START != null) && (rollNo == START.rollNumber))
                {
                    Console.WriteLine("\n Duplikat nomor roll number tidak diizinkan\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while((current!=null)&&(rollNo>=current.rollNumber))
            {
                if(rollNo==current.rollNumber )
                {
                    Console.WriteLine("\n Duplikat roll number tidak diizinkan");
                    return;
                }
                previous = current;
                current = current.next;
            }

            newnode.next = current;
            previous.next = newnode;
        }

        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;

            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (rollNo != current.rollNumber))
            {
                previous = current;
                current = current.next;

            }
            if (current == null)
                return (false);
            else
                return(true);
        }

        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nDaftar kosong");
            else
            {
                Console.WriteLine("\n Record dalam daftar adalah: \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                Console.WriteLine();
            }
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("\n1. Tambahkan catatan ke daftar");
                    Console.WriteLine("\n2. Hapus catatan dari daftar");
                    Console.WriteLine("\n3. Lihat semua catatan dalam daftar");
                    Console.WriteLine("\n4. Cari catatan dalam daftar");
                    Console.WriteLine("\nExit");
                    Console.Write("\nPilih [1 - 5]: ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\n Daftar kosong");
                                    break;
                                }
                                Console.Write("\n Masukkan roll number " + " Siswa yang catatannya akan dihapus: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("\n Catatan tidak ditemukan");
                                else
                                    Console.WriteLine("\nRekam dengan nomor roll " + rollNo + " dihapus");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\n Daftar kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan roll number " + " Siswa yang catatannya akan dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\n Catatan tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\n Catatan  ditemukan");
                                    Console.WriteLine("\n Roll Number: " + current.rollNumber);
                                    Console.WriteLine("\n Nama" + current.name);
                                }
                            }
                            break;
                        case '5':
                            return;

                        default:
                            {
                                Console.WriteLine("\n Opsi Invalid");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n Periksa nilai yang dimasukkan.");
                }
            }
        }
    }
}
