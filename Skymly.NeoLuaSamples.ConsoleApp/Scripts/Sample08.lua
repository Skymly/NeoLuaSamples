﻿local se = clr.Skymly.NeoLuaSamples.ConsoleApp.SampleEnum

--获取枚举项
print(se.Red)

--转换类型

local f = clr.Skymly.NeoLuaSamples.ConsoleApp.SampleFlagEnum

--使用cast强转

local num1 = cast(int,f.金属);
print('金属:' .. num1)

local num3 = cast (int,f.非金属);
print('非金属:' .. num3)



--Flag运算

local f1 = f.金属 | f.液态 | f.有毒

local v1 = cast (int , f1);
print(f1 .. ':' .. v1)

local function PrintHasFlag( source, item )
	print( '[' .. source ..'].HasFlag(' .. item .. ') = ' ..source.HasFlag(item))
end

PrintHasFlag(f1,f.金属)
PrintHasFlag(f1,f.液态)
PrintHasFlag(f1,f.有毒)
PrintHasFlag(f1,f.气态)


--Useage Sample
local SampleModel = clr.Skymly.NeoLuaSamples.ConsoleApp.SampleModel;
local BindingFlags = clr.System.Reflection.BindingFlags;

local flags = BindingFlags.Public | BindingFlags.Instance;
local propAttr =  SampleModel:GetType().GetProperties(flags);--反射获取SampleModel类的公开实例属性。

print("SampleModel类的公开实例属性共有" .. propAttr.Length .. '个,分别是：');
for i=0,#propAttr-1 do
	print(propAttr[i].Name)
end










