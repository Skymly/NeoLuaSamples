﻿

local json = m.ToJson();
print(json)

local str = m.ToString();
print(str);

local circumference =  m.GetCircumference(3);
print("半径3的圆形周长是"..circumference);



local Model = clr.Skymly.NeoLuaSamples.ConsoleApp.SampleModel
Model.PrintMessage();

m.SetName("张三").SetName("李四").SetName("王五").SetName("赵六");



--Call ExtensionMethod
--[[
	使用扩张方法必须先注册扩展方法 以下2种方式都可以做到：
	C#:  LuaType.RegisterTypeExtension(typeof(SomeExtensionType));
	Lua: clr.Neo.IronLua.LuaType:RegisterTypeExtension(clr.SomeExtensionType);
]]

--clr.Neo.IronLua.LuaType:RegisterTypeExtension(clr.Skymly.NeoLuaSamples.ConsoleApp.SampleModelExtensions)
m:Say()

--如果没有注册拓展方法 也可以直接按照静态方法来调用
clr.Skymly.NeoLuaSamples.ConsoleApp.SampleModelExtensions:Say(m)