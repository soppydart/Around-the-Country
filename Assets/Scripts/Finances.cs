using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finances : MonoBehaviour
{
    public int[] ownedCard = new int[24];
    public string[] startingCompanies = {"Lakshmi Coaching Center", " Swachh Aata Flour Mill", "Neon Scooba Divers",
    "RecycleIt"};
    public double[] startingCompaniesTotalValue = { 4500, 3500, 4000, 5500 };
    public double[,] startingCompaniesIncome = {{-0.1, -1.4, -0.6, -2.4, 5.6, 6.7, 10.8, 12.9, 8.7, 4.9},
    {4.5, 3.9, 1.7, -0.9, 7.6, 7.8, 3.5, -1.6, -0.3, 3.9},{2.4, 8.7, -3.7, 6.1, 5.1, 7.1, -3.6, 7.3, 5.8, -7.2},
    {12.6, 10.9, 5.7, 7.5, -14.6, -8.8, -8.7, -10.5, -10.3, -13.7}};
    public string[] mysteryCards ={"You won a lottery of Rs. 2500!", "You found Rs. 500 lying on the road!",
    "You were pickpocketed. You lost Rs. 750!","You got into an accident and broke a leg! Play Rs. 600 as Hospital Fee.",
    "You were found drinking and driving and paid Rs. 1500 as fine!"};

    public int[] mysteryLoss = { -2500, -500, 750, 600, 1500 };
    public string[] cardNames = {"Start 1","Hotel","Department Store","Mystery","Pizza Restaurant", "Game Center",
    "Start 2", "Inn", "Farm","Mystery", "Fishing Pond","Jail", "Start 3", "Seafood Restaurant", "Mystery",
    "Boat Rental", "Sting Ray", "Beach Lodge", "Start 4", "IT Company", "Automobile Factory", "Mystery",
    "Textile Warehouse", "Empty Plot Of Land"};

    public int[] prices = { 0, 1500, 3000, 0, 800, 1000, 0, 600, 1000, 0, 400, 0, 0, 1200, 0, 500, 0, 1800, 0, 4000,
    2800, 0, 2200, 600};

    public int[] loss = { 0, 200, 150, 0, 100, 50, 0, 50, 20, 0, 10, 100, 0, 120, 0, 150, 80, 180, 0, 300, 240, 0,
    50, 100};

    public string[] lossMessage = {"", "You stayed at the hotel for a night. Pay Rs. 200", "You went on a shopping spree. Pay Rs. 150",
    "", "You had a large cheese-mushroom pizza. Pay Rs. 100", "You played CSGO for 4 hours. Pay Rs 50",
    "", "You stayed at the inn for a night. Pay Rs. 50.", "You bought fresh vegetables from the farm. Pay Rs. 20",
    "", "You tried your luck on fishing but accidentally broke the rod. Pay Rs. 10",
    "You were falsely accused of stealing chickens from a poultry by a poor man. You agreed to go to Jail, pay a fine,and miss the next turn. Pay Rs. 100",
    "", "You had prawn and oysters for lunch. Pay Rs. 120", "", "You strayed too far from the beach on the boat and got lost. Pay Rs. 150",
    "You were stung by a sting ray and rushed to the nearest hospital. Pay Rs. 80", "You stayed at the lodge in a room with the sea view for a night. Pay Rs. 180",
    "", "You were pursuaded by a salesman to buy the company's shares. Pay Rs. 300", "You accidentally destroyed a machine while on a factory tour. Pay Rs. 240",
    "", "You purchased good-quality cloth for a very cheap price. Pay Rs. 50",
    "You were roaming around in the land when a snake bit you. You were rushed to a hospital. Pay Rs. 100"};

    public string[] CompanyBuyerName = { "Unacademy", "A small startup", "Google", "Mukesh Ambani" };
    public int[] CompanyBuyerPrices = { 4000, 3750, 5000, 7000 };
    void Start()
    {
        for (int i = 0; i < 24; i++)
        {
            ownedCard[i] = -1;
        }
    }
}
