local SampleModel = clr.Skymly.NeoLuaSamples.Tests.SampleModel

local PrintType = function(x)
	print("Lua Type:" .. type(x) )
	print(".Net Type:" .. x.GetType().FullName)
end

local function PrintModel(x)-- call instance values
	print("call instance values")
	print(x.Name) -- call property
	print(x.age)  -- call field
 	print(x.NameLength) -- call readonly property
end

local function CallStaticValues() -- call static values
	print("call static values")
	print(SampleModel.PI) -- call constant
	print(SampleModel.Num) -- call static field
	print(SampleModel.Message) -- call static property

	print(SampleModel:PI) -- call constant
	print(SampleModel:Num) -- call static field
	print(SampleModel:Message) -- call static property
end


PrintType(m1);
PrintModel(m1);

PrintType(m2);
PrintModel(m2);

CallStaticValues();

do --set values
	m1.Name = "Hello"
	print("修改之后的m1.Name = " .. m1.Name)
	SampleModel.Message = "cooooool";
	print("修改之后的SampleModel.Message = " .. SampleModel.Message )
end


