using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Ticket
{
    // Variabelen
    private int concert;
    private int bestelling;
    private bool korting;

    // Properties (getters)
    public int Concert
    {
        get { return concert; }
    }

    public bool Korting
    {
        get { return korting; }
    }

    // Contructor
    public Ticket(int concert, bool korting)
    {
        this.concert = concert;
        this.korting = korting;
    }

    // ToString() method
    /*
    public override string ToString()
    {
        
    }
    */
}