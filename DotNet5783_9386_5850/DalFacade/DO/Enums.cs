
namespace DO;

public partial struct Enums
{ 
    public enum CostumerNames {Shimon,David,Reuben,Yakov,Shlomo,Moshe,Yuval,Elad,Omer,Yonatan}
    public enum CostumerAdress { Shimon74, David13, Reuben2, Yakov8, Shlomo65, Moshe27, Yuval44, Elad35, Omer24, Yonatan79 }
    public enum Category {vegetables,Meat,Legumes,DairyProducts,CleanProducts}
    public enum Vegetables {Tomatoes, Cucumbers, Potatoes, SweetPotatoes, Peppers, Garlic, Onion, Cabbage, Squash,Eggplant}
    public enum Pricesvegetables { Tomatoes = 5, Cucumbers = 4, Potatoes = 4, SweetPotatoes = 4, Peppers = 4, Garlic = 2 , Onion = 3, Cabbage = 4, Squash = 4, Eggplant = 5}
    public enum Meat { ChickenBreast, Beef, ChickenWings,Entrecote,Steak, ChickenHearts }
    public enum PricesMeat { ChickenBreast = 10, Beef = 20, ChickenWings = 7, Entrecote = 16, Steak = 17, ChickenHearts = 13 }

    public enum Legumes {Hummus, Beans, Peas, Wheat }
    public enum PricesLegumes { Hummus = 7, Beans = 6, Peas = 6, Wheat = 5 }

    public enum DairyProducts {Milk, Cheese, ButterCream,  CottageCheese, Yogurt  }
    public enum PricesDairyProducts { Milk = 4, Cheese = 5  , ButterCream = 8, CottageCheese = 7, Yogurt = 6 }

    public enum CleanProducts { Shampoo, Soap, FloorLiquid, DishSoap, Cloth}
    public enum PricesCleanProducts { Shampoo = 10, Soap = 7, FloorLiquid = 11, DishSoap = 8, Cloth = 5 }


}