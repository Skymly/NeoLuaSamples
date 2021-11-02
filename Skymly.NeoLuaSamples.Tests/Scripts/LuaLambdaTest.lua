
local LambdaTestModel= clr.Skymly.NeoLuaSamples.Tests.LambdaTestModel



local obj = LambdaTestModel();

print(obj.Id);

local TestFunc = function()
	return 5;
end

local a = obj.Get(TestFunc);
print(a)
