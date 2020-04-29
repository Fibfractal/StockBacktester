# -- StockBacktester --


# Purpose

It's a windows desktop application and the purpose is to test stock strategies and see if they are profitable and robust.
It downloads Nasdaq 100 daily price data from an API in JSON-format and saves it in a local SQL DB.  

The initial GUI let you pick a stock and an algo to perform a backtest on the selected timeperiod. Buy and sell signals can be seen in the graph. The backtest consists of key numbers and a graph of the portfolio performance.

The second GUI let you perform a strategy an all stocks at the same time, to see if it's robust. You can test it on 30, 70 % or all data. Filters are set to see if it PASS or FAIL your demands.


# Getting started

1. Open the solution.

2. Publish the database in the solution as a local db named exactly "SqlDataBase".
Do so by open the "Published profiles" folder under "SqlDataBase" project in the solution.
There, right click on the "SqlDataBase.publish.xml" and publish, now the the DB and stock tables are created.

3. Now you can run the solution, and start with updating the stockdata, it will take 5-10 min depending on how busy the API is.


# Creation of a new algo

1. Use the code structure from the 3 dummy algos already created in the folder "Trading algos" in the solution.
That is; create a class that have one buy method and one sell method, that returns true or false.

2. The indicator structures available are MA and RSI, found under "Indicators".

3. When the algo is created, add the name of the algo in the class "EnumOfAlgos".
Also add it to the "AlgoPicker" class. There, see the present structure and add it to "PickAlgoBuy" and "PickAlgoSell" methods.

4. Now your algo shall be available in the GUI.


# Test filters

1. Set the filters in the class "MultipleBacktestDemand" in the folder "Backtest multiple stocks".

2. The tresholds are in the private fields.


# Limitations at this point

1. The API only updates Nasdaq 100 stocks daily data.

2. The library used to plot the price timeseries is slow, 4 month is pre-selected to show in the graph, to be responsive.
The graph is used to visualy see if the buy and sell signals are shown and placed as expected. You can hide the graph
under tools, and only see the backtest for that stock, when you want to test long timeseries and have fast calculations.


# The next step

1. The next step is to create a stock screener for the current stocks signals.



