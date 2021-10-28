
local json = m.ToJson();
print(json)

local str = m.ToString();
print(str);

local circumference =  m.GetCircumference(3);
print("半径3的圆形周长是"..circumference);


local Model = clr.Skymly.NeoLuaSamples.ConsoleApp.SampleModel
Model.PrintMessage();

m.SetName("张三").SetName("李四").SetName("王五").SetName("赵六");