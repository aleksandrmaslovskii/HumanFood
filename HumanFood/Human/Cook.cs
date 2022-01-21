using HumanFood.Food;

namespace HumanFood.Human;

internal record Cook(IFeed Feeded, IHuman Human)
{
    public void Feed(IFood food) => Feeded.Eat(food);
    public void Ask() => Human.Answer();
}