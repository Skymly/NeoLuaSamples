
--在lua中使用.NET的构造方法创建对象

local SampleModel = clr.Skymly.NeoLuaSamples.Tests.SampleModel;

--调用无参构造方法
local obj1 = SampleModel();
obj1.SetName("张三").age = 15;
obj1.ShowJson();



--调用含参构造方法
local obj2 = SampleModel("狗蛋",6);
obj2.ShowJson();


--使用  const 类型别名 typeof 类型全名

const Model typeof Skymly.NeoLuaSamples.Tests.SampleModel;

local obj3 = Model();
obj3.Name = "夏侯惇" 
obj3.age = 30
obj3.ShowJson();

local obj4:Model = Model("曹操",50);
obj4.ShowJson();

