using System.Diagnostics;

namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        float VitoriasO = 0;
        float VitoriasX = 0;

        public MainPage()
        {
            InitializeComponent();
            Zerar();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.IsEnabled = false;

            if(vez == "X")
            {
                btn.Text = "X";
                MostradorDeVez.Text = "Vez do O";
                vez = "O";
                VerificarVelha();
            }
            else
            {
                btn.Text = "O";
                MostradorDeVez.Text = "Vez do X";
                vez = "X";
                VerificarVelha();
            }

            // Verificador vitoria do X ou O
            
            bool VerificarVitoria(string simbolo)
            {
            return (btn10.Text == simbolo && btn11.Text == simbolo && btn12.Text == simbolo) || // linha 1
           (btn20.Text == simbolo && btn21.Text == simbolo && btn22.Text == simbolo) || // linha 2
           (btn30.Text == simbolo && btn31.Text == simbolo && btn32.Text == simbolo) || // linha 3
           (btn10.Text == simbolo && btn20.Text == simbolo && btn30.Text == simbolo) || // coluna 1
           (btn11.Text == simbolo && btn21.Text == simbolo && btn31.Text == simbolo) || // coluna 2
           (btn12.Text == simbolo && btn22.Text == simbolo && btn32.Text == simbolo) || // coluna 3
           (btn10.Text == simbolo && btn21.Text == simbolo && btn32.Text == simbolo) || // diagonal 1 
           (btn30.Text == simbolo && btn21.Text == simbolo && btn12.Text == simbolo);   // diagonal 2

            }
    
            //Verificador se deu velha

            bool VerificarVelha()
            {
                return btn10.Text != "" && btn20.Text != ""  && btn30.Text != "" 
                    && btn11.Text != ""  && btn21.Text != ""  && btn31.Text != "" 
                    && btn12.Text != ""  && btn20.Text != "" && btn32.Text != "";   
            }

            //Resultado final

            if (VerificarVitoria("X"))
            {
                VitoriasX++;
                lblVitoriasX.Text = VitoriasX.ToString(); // atualiza o label com as vitorias do X
                DisplayAlert("Parábens!!", "O X Ganhou", "OK");
                Zerar();
            }
            else if (VerificarVitoria("O"))
            {
                VitoriasO++;
                lblVitoriasO.Text = VitoriasO.ToString(); // atualiza o label com as vitorias do O
                DisplayAlert("Parábens!!", "O O Ganhou", "OK");
                Zerar();
            }

            else if(VerificarVelha())
            {
                DisplayAlert("Eita", "Deu velha!!", "OK");
                Zerar();
            }
 
        }
      
        void Zerar()
        {

            vez = "X";

            Debug.Print("Zerando primeira linha.");

            btn10.IsEnabled = true;
            btn11.IsEnabled = true;
            btn12.IsEnabled = true;

            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";

            Debug.Print("Zerando segunda linha.");

            btn20.IsEnabled = true;
            btn21.IsEnabled = true;
            btn22.IsEnabled = true;

            btn20.Text = "";
            btn21.Text = "";
            btn22.Text = "";

            Debug.Print("Zerando terceira linha.");

            btn30.IsEnabled = true;
            btn31.IsEnabled = true;
            btn32.IsEnabled = true;

            btn30.Text = "";
            btn31.Text = "";
            btn32.Text = "";
        }


    } // Classe

}// Namespace
