using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Frogger
{
    public class Hindernis
    {
        // Diese Klasse beinhaltet alle Felder, die zur Darstellung eines Hindernisses notwendig ist.

        // Position
        public int X;
        public int Y;

        // Dimension
        public int Width;
        public int Height;

        // Geschwindigkeit
        public int Speed;

        // Zeichenmittel
        // Damit man Zeichenmittel nutzen kann, muss System.Drawing importiert werden (oben bei using...)
        public int Color;

        public bool richtung;

        public int Type;

        public bool carryPlayer1 = false;
        public int spieler1InBereich = -1;
        public bool carryPlayer2 = false;
        public int spieler2InBereich = -1;

        public Rectangle Rectangle { get { return new Rectangle(X, Y, Width, Height); } }


        public Hindernis(int X, int Y, int Width, int Height, int Speed, int Color, bool richtung, int type)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Speed = Speed;
            this.Color = Color;
            this.richtung = richtung;
            Type = type;
        }

        public void Move()
        {
            if (richtung)
            {
                if (carryPlayer1 && spieler1InBereich == FrmFrogger.spieler1InBereich)
                {
                    FrmFrogger.spieler1.X = FrmFrogger.spieler1.X - Speed;

                    if (FrmFrogger.spieler1.Left < 0)
                    {
                        FrmFrogger.GameOver(true);
                    }
                }
                else
                {
                    carryPlayer1 = false;
                    spieler1InBereich = -1;
                }

                if (carryPlayer2 && spieler2InBereich == FrmFrogger.spieler2InBereich)
                {
                    FrmFrogger.spieler2.X = FrmFrogger.spieler2.X - Speed;

                    if (FrmFrogger.spieler2.Left < 0)
                    {
                        FrmFrogger.GameOver(false);
                    }
                }
                else
                {
                    carryPlayer2 = false;
                    spieler2InBereich = -1;
                }

                this.X = this.X - Speed;
            }
            else
            {
                if (carryPlayer1 && spieler1InBereich == FrmFrogger.spieler1InBereich)
                {
                    FrmFrogger.spieler1.X = FrmFrogger.spieler1.X + Speed;

                    if (FrmFrogger.spieler1.Right > FrmFrogger.breite)
                    {
                        FrmFrogger.GameOver(true);
                    }
                }
                else
                {
                    carryPlayer1 = false;
                    spieler1InBereich = -1;
                }

                if (carryPlayer2 && spieler2InBereich == FrmFrogger.spieler2InBereich)
                {
                    FrmFrogger.spieler2.X = FrmFrogger.spieler2.X + Speed;

                    if (FrmFrogger.spieler2.Right > FrmFrogger.breite)
                    {
                        FrmFrogger.GameOver(false);
                    }
                }
                else
                {
                    carryPlayer2 = false;
                    spieler2InBereich = -1;
                }

                this.X = this.X + Speed;
            }
        }

    }
}
