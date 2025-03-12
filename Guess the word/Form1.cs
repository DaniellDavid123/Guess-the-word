using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Guess_the_word
{
    public partial class Form1 : Form
    {
        private string wordToGuess = "computer"; // The correct word
        private StringBuilder maskedWord; // Masked version of the word

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
       
        

        private void InitializeGame()
        {
            maskedWord = new StringBuilder(wordToGuess.Length);

            
            maskedWord.Append(wordToGuess[0]); 
            for (int i = 1; i < wordToGuess.Length - 1; i++)
            {
                maskedWord.Append('?'); 
            }
            maskedWord.Append(wordToGuess[wordToGuess.Length - 1]); 

            label1.Text = maskedWord.ToString();
        }

        private void txtbox1_TextChanged(object sender, EventArgs e)
        {
            if (txtbox1.Text.Any(char.IsUpper)) 
            {
                txtbox1.Text = txtbox1.Text.ToLower(); 
                txtbox1.SelectionStart = txtbox1.Text.Length; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userGuess = txtbox1.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(userGuess))
            {
                MessageBox.Show("Please enter a word.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userGuess == wordToGuess)
            {
                label1.Text = wordToGuess;
                MessageBox.Show("Congratulations! You guessed it right!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listBox1.Items.Add(userGuess);
                MessageBox.Show("Wrong guess, try again!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
