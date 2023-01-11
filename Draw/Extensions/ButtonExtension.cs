using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    static class ButtonExtension
    {
        //Genişletme 
        //Butonu yok ise listeye ekler ve hepsinin gölgesini kaldırır.
        private static void ActiveButton(this Button button, List<Button> buttonList)
        {
            if (!buttonList.Contains(button))
                buttonList.Add(button);
            foreach (var btn in buttonList)
            {
                btn.FlatAppearance.BorderSize = 1;
            }
        }
        //Çift tıklama ile butonun gölgesini açıp kapatır.
        public static void SelectActiveButtonDoubleClick(this Button button, List<Button> buttonList)
        {
            bool isActive = button.FlatAppearance.BorderSize == 5;
            ActiveButton(button, buttonList);
            if (!isActive)
                button.FlatAppearance.BorderSize = 5;
        }
        //Tek tıklama ile butonun gölgesini açar
        public static void SelectActiveButton(this Button button, List<Button> buttonList)
        {
            ActiveButton(button, buttonList);
            button.FlatAppearance.BorderSize = 5;
        }







    }
}

