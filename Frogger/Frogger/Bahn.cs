using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class Bahn
    {
        private int spawnZaehler;
        private Rectangle rectangle;
        private SolidBrush solidBrush;
        private int spawnRate;
        private List<Hindernis> alleHindernisse = new List<Hindernis>();
        int type = 0;
        int speedHindernis = 0;
        private bool richtung;
        private int carLenght;

        public int SpawnZaehler { get { return spawnZaehler; } set { spawnZaehler = value; } }
        public Rectangle Rectangle { get { return rectangle; } }
        public SolidBrush SolidBrush { get { return solidBrush; } }
        public int SpawnRate { get { return spawnRate; } }
        public List<Hindernis> AlleHindernisse { get { return alleHindernisse; } set { alleHindernisse = value; } }
        public int Type { get { return type; } }
        public int SpeedHindernis { get { return speedHindernis; } }
        public bool Richtung { get { return richtung; } }


        public Bahn(Rectangle rectangle, int type)
        {
            this.rectangle = rectangle;
            this.type = type;

            alleHindernisse = new List<Hindernis>();

            switch (type)
            {
                case 0:
                    spawnRate = 0;
                    spawnZaehler = 0;
                    speedHindernis = 0;
                    richtung = true;
                    solidBrush = new SolidBrush(Color.LightGreen);
                    carLenght = 0;

                    for (int i = 0; i < FrmFrogger.breite / FrmFrogger.hoeheJeBereich; i++)
                    {
                        if (FrmFrogger.blockadeSpawnRate > 0 && FrmFrogger.rndBahn.Next((int) FrmFrogger.blockadeSpawnRate) == 0)
                        {
                            alleHindernisse.Add(new Hindernis(i * FrmFrogger.hoeheJeBereich, rectangle.Top, FrmFrogger.hoeheJeBereich, FrmFrogger.hoeheJeBereich, 0, FrmFrogger.rndBahn.Next(1), richtung, FrmFrogger.rndBahn.Next(2) + 1));
                        }
                    }
                    break;
                case 1:
                    carLenght = 60;
                    spawnZaehler = FrmFrogger.rndBahn.Next(10);

                    if (FrmFrogger.carSpawnRateFrom < FrmFrogger.carSpawnRateTo && ((int) (FrmFrogger.carSpawnRateTo - FrmFrogger.carSpawnRateFrom)) > 0)
                    {
                        spawnRate = FrmFrogger.rndBahn.Next((int) (FrmFrogger.carSpawnRateTo - FrmFrogger.carSpawnRateFrom)) + (int )FrmFrogger.carSpawnRateFrom;
                    }
                    else
                    {
                        spawnRate = (int) FrmFrogger.carSpawnRateFrom;
                    }

                    if (FrmFrogger.carSpeedFrom < FrmFrogger.carSpawnRateTo && ((int) (FrmFrogger.carSpawnRateTo - FrmFrogger.carSpeedFrom)) > 0)
                    {
                        speedHindernis = FrmFrogger.rndBahn.Next((int) (FrmFrogger.carSpawnRateTo - FrmFrogger.carSpeedFrom)) + (int) FrmFrogger.carSpeedFrom;
                    }
                    else
                    {
                        speedHindernis = (int) FrmFrogger.carSpeedFrom;
                    }

                    richtung = Convert.ToBoolean(FrmFrogger.rndBahn.Next(2));

                    solidBrush = new SolidBrush(Color.Gray);
                    for (int i = 0; i < 50; i++)
                    {
                        UpdateBahn();
                    }
                    break;
                case 2:
                    carLenght = 800;
                    spawnZaehler = FrmFrogger.rndBahn.Next(10);

                    if (FrmFrogger.trainSpawnRateFrom < FrmFrogger.trainSpawnRateTo && ((int) (FrmFrogger.trainSpawnRateTo - FrmFrogger.trainSpawnRateFrom)) > 0)
                    {
                        spawnRate = FrmFrogger.rndBahn.Next((int) (FrmFrogger.trainSpawnRateTo - FrmFrogger.trainSpawnRateFrom)) + (int) FrmFrogger.trainSpawnRateFrom;
                    }
                    else
                    {
                        spawnRate = (int) FrmFrogger.trainSpawnRateFrom;
                    }

                    if (FrmFrogger.trainSpeedFrom < FrmFrogger.trainSpeedTo && ((int) (FrmFrogger.trainSpeedTo - FrmFrogger.trainSpeedFrom)) > 0)
                    {
                        speedHindernis = FrmFrogger.rndBahn.Next((int) (FrmFrogger.trainSpeedTo - FrmFrogger.trainSpeedFrom)) + (int) FrmFrogger.trainSpeedFrom;
                    }
                    else
                    {
                        speedHindernis = (int) FrmFrogger.trainSpeedFrom;
                    }

                    richtung = Convert.ToBoolean(FrmFrogger.rndBahn.Next(2));

                    solidBrush = new SolidBrush(Color.DarkGray);
                    for (int i = 0; i < 50; i++)
                    {
                        UpdateBahn();
                    }
                    break;
                case 3:
                    carLenght = 60;
                    spawnZaehler = FrmFrogger.rndBahn.Next(10);

                    if (FrmFrogger.raftSpawnRateFrom < FrmFrogger.raftSpawnRateTo && ((int) (FrmFrogger.raftSpawnRateTo - FrmFrogger.raftSpawnRateFrom)) > 0)
                    {
                        spawnRate = FrmFrogger.rndBahn.Next((int) (FrmFrogger.raftSpawnRateTo - FrmFrogger.raftSpawnRateFrom)) + (int) FrmFrogger.raftSpawnRateFrom;
                    }
                    else
                    {
                        spawnRate = (int) FrmFrogger.raftSpawnRateFrom;
                    }

                    if (FrmFrogger.raftSpeedFrom < FrmFrogger.raftSpeedTo && ((int) (FrmFrogger.raftSpeedTo - FrmFrogger.raftSpeedFrom)) > 0)
                    {
                        speedHindernis = FrmFrogger.rndBahn.Next((int) (FrmFrogger.raftSpeedTo - FrmFrogger.raftSpeedFrom)) + (int)FrmFrogger.raftSpeedFrom;
                    }
                    else
                    {
                        speedHindernis = (int) FrmFrogger.raftSpeedFrom;
                    }

                    richtung = Convert.ToBoolean(FrmFrogger.rndBahn.Next(2));

                    solidBrush = new SolidBrush(Color.Blue);
                    for (int i = 0; i < 50; i++)
                    {
                        UpdateBahn();
                    }
                    break;
            }
        }

        public void UpdateBahn()
        {
            switch (type)
            {
                case 1:
                    spawnZaehler++;

                    if (spawnZaehler >= spawnRate)
                    {
                        if (richtung)
                        {
                            alleHindernisse.Add(new Hindernis(FrmFrogger.breite, rectangle.Top, carLenght, FrmFrogger.hoeheJeBereich, speedHindernis, FrmFrogger.rndBahn.Next(1), richtung, 0));
                        }
                        else
                        {
                            alleHindernisse.Add(new Hindernis(-carLenght, Rectangle.Top, carLenght, FrmFrogger.hoeheJeBereich, speedHindernis, FrmFrogger.rndBahn.Next(1), richtung, 0));
                        }

                        spawnZaehler = 0;
                    }

                    CheckForCollision();

                    for (int j = alleHindernisse.Count - 1; j >= 0; j--)
                    {
                        alleHindernisse[j].Move();

                        if (richtung)
                        {
                            if (alleHindernisse[j].X <= -carLenght)
                            {
                                alleHindernisse.RemoveAt(j);
                            }
                        }
                        else
                        {
                            if (alleHindernisse[j].X >= FrmFrogger.breite)
                            {
                                alleHindernisse.RemoveAt(j);
                            }
                        }
                    }
                    break;
                case 2:
                    spawnZaehler++;

                    if (spawnZaehler >= spawnRate)
                    {
                        if (richtung)
                        {
                            alleHindernisse.Add(new Hindernis(FrmFrogger.breite, rectangle.Top, carLenght, FrmFrogger.hoeheJeBereich, speedHindernis, FrmFrogger.rndBahn.Next(1), richtung, 3));
                        }
                        else
                        {
                            alleHindernisse.Add(new Hindernis(-carLenght, Rectangle.Top, carLenght, FrmFrogger.hoeheJeBereich, speedHindernis, FrmFrogger.rndBahn.Next(1), richtung, 3));
                        }

                        spawnZaehler = 0;
                    }

                    CheckForCollision();

                    for (int j = alleHindernisse.Count - 1; j >= 0; j--)
                    {
                        alleHindernisse[j].Move();

                        if (richtung)
                        {
                            if (alleHindernisse[j].X <= -carLenght)
                            {
                                alleHindernisse.RemoveAt(j);
                            }
                        }
                        else
                        {
                            if (alleHindernisse[j].X >= FrmFrogger.breite)
                            {
                                alleHindernisse.RemoveAt(j);
                            }
                        }
                    }
                    break;
                case 3:
                    spawnZaehler++;

                    if (spawnZaehler >= spawnRate)
                    {
                        if (richtung)
                        {
                            alleHindernisse.Add(new Hindernis(FrmFrogger.breite, rectangle.Top, carLenght, FrmFrogger.hoeheJeBereich, speedHindernis, FrmFrogger.rndBahn.Next(1), richtung, 4));
                        }
                        else
                        {
                            alleHindernisse.Add(new Hindernis(-carLenght, Rectangle.Top, carLenght, FrmFrogger.hoeheJeBereich, speedHindernis, FrmFrogger.rndBahn.Next(1), richtung, 4));
                        }

                        spawnZaehler = 0;
                    }

                    CheckForCollision();

                    for (int j = alleHindernisse.Count - 1; j >= 0; j--)
                    {
                        alleHindernisse[j].Move();

                        if (richtung)
                        {
                            if (alleHindernisse[j].X <= -carLenght)
                            {
                                alleHindernisse.RemoveAt(j);
                            }
                        }
                        else
                        {
                            if (alleHindernisse[j].X >= FrmFrogger.breite)
                            {
                                alleHindernisse.RemoveAt(j);
                            }
                        }
                    }
                    break;
            }
        }

        public void CheckForCollision()
        {
            foreach (Hindernis aktuellesHindernis in alleHindernisse)
            {
                if (!FrmFrogger.gameOverPlayer1 && aktuellesHindernis.Rectangle.IntersectsWith(FrmFrogger.spieler1) && (aktuellesHindernis.Type == 0 || aktuellesHindernis.Type == 3))
                {
                    FrmFrogger.GameOver(true);
                }

                if (FrmFrogger.secondPlayer && !FrmFrogger.gameOverPlayer2 && aktuellesHindernis.Rectangle.IntersectsWith(FrmFrogger.spieler2) && (aktuellesHindernis.Type == 0 || aktuellesHindernis.Type == 3))
                {
                    FrmFrogger.GameOver(false);
                }
            }
        }

        public bool CheckForCollision(short route, bool player)
        {
            Rectangle tmpPlayer;
            if (player)
            {
                tmpPlayer = new Rectangle(FrmFrogger.spieler1.X, FrmFrogger.spieler1.Y, FrmFrogger.spieler1.Width, FrmFrogger.spieler1.Height);

                switch (route)
                {
                    case 0:
                        tmpPlayer = new Rectangle(FrmFrogger.spieler1.X, FrmFrogger.spieler1.Y - FrmFrogger.hoeheJeBereich, FrmFrogger.spieler1.Width, FrmFrogger.spieler1.Height);
                        break;
                    case 1:
                        tmpPlayer = new Rectangle(FrmFrogger.spieler1.X, FrmFrogger.spieler1.Y + FrmFrogger.hoeheJeBereich, FrmFrogger.spieler1.Width, FrmFrogger.spieler1.Height);
                        break;
                    case 2:
                        tmpPlayer = new Rectangle(FrmFrogger.spieler1.X - FrmFrogger.hoeheJeBereich, FrmFrogger.spieler1.Y, FrmFrogger.spieler1.Width, FrmFrogger.spieler1.Height);
                        break;
                    case 3:
                        tmpPlayer = new Rectangle(FrmFrogger.spieler1.X + FrmFrogger.hoeheJeBereich, FrmFrogger.spieler1.Y, FrmFrogger.spieler1.Width, FrmFrogger.spieler1.Height);
                        break;
                }
            }
            else
            {
                tmpPlayer = new Rectangle(FrmFrogger.spieler2.X, FrmFrogger.spieler2.Y, FrmFrogger.spieler2.Width, FrmFrogger.spieler2.Height);

                switch (route)
                {
                    case 0:
                        tmpPlayer = new Rectangle(FrmFrogger.spieler2.X, FrmFrogger.spieler2.Y - FrmFrogger.hoeheJeBereich, FrmFrogger.spieler2.Width, FrmFrogger.spieler2.Height);
                        break;
                    case 1:
                        tmpPlayer = new Rectangle(FrmFrogger.spieler2.X, FrmFrogger.spieler2.Y + FrmFrogger.hoeheJeBereich, FrmFrogger.spieler2.Width, FrmFrogger.spieler2.Height);
                        break;
                    case 2:
                        tmpPlayer = new Rectangle(FrmFrogger.spieler2.X - FrmFrogger.hoeheJeBereich, FrmFrogger.spieler2.Y, FrmFrogger.spieler2.Width, FrmFrogger.spieler2.Height);
                        break;
                    case 3:
                        tmpPlayer = new Rectangle(FrmFrogger.spieler2.X + FrmFrogger.hoeheJeBereich, FrmFrogger.spieler2.Y, FrmFrogger.spieler2.Width, FrmFrogger.spieler2.Height);
                        break;
                }
            }

            switch (type)
            {
                case 3:
                    foreach (Hindernis aktuellesHindernis in alleHindernisse)
                    {
                        if (aktuellesHindernis.Rectangle.IntersectsWith(tmpPlayer) && (aktuellesHindernis.Type == 4))
                        {
                            if (player)
                            {
                                aktuellesHindernis.carryPlayer1 = true;

                                if (route == 0)
                                {
                                    aktuellesHindernis.spieler1InBereich = FrmFrogger.spieler1InBereich + 1;
                                }
                                else if (route == 1)
                                {
                                    aktuellesHindernis.spieler1InBereich = FrmFrogger.spieler1InBereich - 1;
                                }
                            }
                            else
                            {
                                aktuellesHindernis.carryPlayer2 = true;

                                if (route == 0)
                                {
                                    aktuellesHindernis.spieler2InBereich = FrmFrogger.spieler2InBereich + 1;
                                }
                                else if (route == 1)
                                {
                                    aktuellesHindernis.spieler2InBereich = FrmFrogger.spieler2InBereich - 1;
                                }
                            }

                            return true;
                        }
                    }

                    return false;
                default:
                    foreach (Hindernis aktuellesHindernis in alleHindernisse)
                    {
                        if (aktuellesHindernis.Rectangle.IntersectsWith(tmpPlayer) && (aktuellesHindernis.Type == 1))
                        {
                            return false;
                        }
                    }

                    return true;
            }
        }
    }
}
