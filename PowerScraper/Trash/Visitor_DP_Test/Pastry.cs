namespace PowerScraper.Tonsil.Visitor_DP_Test;

/**
 * This pattern is a way of seperating an algorithm from an object structure.
 * A practical result of this seperation, is the ability to add new operations
 * to existent object structures, without modifying the structures.
 *
 * This pattern follows the open/closed principle.
 */
public abstract class Pastry
{
    public abstract string Description { get; }
    public abstract int KiloCalories { get; }
    public abstract float Price { get; }
    public abstract string Name { get; }
    public abstract void Accept(IPastryVisitor visitor);
}

public class Beignet : Pastry
{
    public override string Description => "A French pastry made from deep-fried dough, typically dusted with powdered sugar.";

    public override int KiloCalories => 250;

    public override float Price => 2.5f;

    public override string Name => "Beignet";

    public Beignet()
    {
    }

    public override void Accept(IPastryVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Cruller : Pastry
{
    public override string Description => "A twisted, sweet pastry made from yeast dough that is deep-fried and often glazed.";

    public override int KiloCalories => 220;

    public override float Price => 1.75f;
    public override string Name => "Cruller";

    public Cruller()
    {
    }

    public override void Accept(IPastryVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public interface IPastryVisitor
{
    void Visit(Beignet beignet);
    void Visit(Cruller cruller);
}

public class PastryInspector : IPastryVisitor
{
    public void Visit(Beignet beignet)
    {
        Console.WriteLine($"This Beignet costs {beignet.Price} and has {beignet.KiloCalories} kcal");
    }

    public void Visit(Cruller cruller)
    {
        Console.WriteLine($"This Cruller costs {cruller.Price} and has {cruller.KiloCalories} kcal");
    }
}

public class PastryReviewer : IPastryVisitor
{
    private List<string> RatingInspectionIncrementors = new()
    {
        "sweet", "deep-fried", "glazed", "sugar"
    };

    private void Rate(Pastry pastry)
    {
        var stars = 0;
        foreach (var ratingIncrementor in RatingInspectionIncrementors)
        {
            if (pastry.Description.Contains(ratingIncrementor))
            {
                stars += 1;
            }
        }

        Console.WriteLine($"This {pastry.Name} gets {new string('*', stars)} stars!");
    }

    public void Visit(Beignet beignet)
    {
        Rate(beignet);
    }

    public void Visit(Cruller cruller)
    {
        Rate(cruller);
    }
}

public static class Runner
{
    public static void Run()
    {
        List<Pastry> pastries = new List<Pastry>()
        {
            new Beignet(),
            new Cruller()
        };
        List<IPastryVisitor> visitors = new List<IPastryVisitor>()
        {
            new PastryReviewer(),
            new PastryInspector()
        };

        foreach (var pastry in pastries)
        {
            foreach (var visitor in visitors)
            {
                pastry.Accept(visitor);
            }
        }
        /*
           This Beignet gets ** stars!
           This Beignet costs 2,5 and has 250 kcal
           This Cruller gets *** stars!
           This Cruller costs 1,75 and has 220 kcal
         */
    }
}