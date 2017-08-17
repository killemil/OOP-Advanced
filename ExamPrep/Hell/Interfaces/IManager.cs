using System.Collections.Generic;

public interface IManager
{
    string AddHero(IList<string> arguments);

    string AddCommonItemToHero(IList<string> arguments);

    string AddRecipeItemToHero(IList<string> arguments);

    string InspectHero(IList<string> arguments);

    string Quit();
}

