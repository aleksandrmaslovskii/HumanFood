using HumanFood.Food;
using HumanFood.Human;
using Microsoft.Extensions.DependencyInjection;

var provider = new ServiceCollection()
    .AddTransient<List<IFood>>()
    .AddScoped<Human>()
    .AddTransient<IFeed>(s => s.GetRequiredService<Human>())
    .AddTransient<IHuman>(s => s.GetRequiredService<Human>())
    .AddTransient<Cook>()
    .BuildServiceProvider();

var firstCook = provider.GetRequiredService<Cook>();
firstCook.Feed(new Orange());

firstCook.Ask();

using var humanFeedScope = provider.CreateScope();
var secondCook = humanFeedScope.ServiceProvider.GetRequiredService<Cook>();
secondCook.Feed(new Peach());
secondCook.Ask();

var thirdCook = humanFeedScope.ServiceProvider.GetRequiredService<Cook>();
thirdCook.Feed(new Watermelon());
thirdCook.Ask();

firstCook.Feed(new Orange());
firstCook.Ask();
