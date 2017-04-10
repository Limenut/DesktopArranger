using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;

namespace DesktopArranger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        struct IconPosition
        {
            public UInt16 x;
            public UInt16 y;

            public IconPosition(UInt16 p1, UInt16 p2)
            {
                x = p1;
                y = p2;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Dictionary<string, IconPosition> positions;
        }

        private Dictionary<string, IconPosition> positionsFromFile(string path)
        {
            Dictionary<string, IconPosition> positions = new Dictionary<string, IconPosition>();
            //byte[] bytes = File.ReadAllBytes(path);
            BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open));

            //move to a loop
            string ID = br.ReadString();
            UInt16 x = br.ReadUInt16();
            UInt16 y = br.ReadUInt16();

            positions.Add(ID, new IconPosition(x, y));

            br.Close();

            return positions;
        }

        private void positionsToFile(string path, Dictionary<string, IconPosition> positions)
        {
            //File.Exists(path)

            BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create));  //create: overwrite or create new

            foreach (KeyValuePair<string, IconPosition> item in positions)
            {
                bw.Write(item.Key);
                IconPosition icon = item.Value;
                bw.Write(icon.x);
                bw.Write(icon.y);
            }

            bw.Close();
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Restore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Undo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
