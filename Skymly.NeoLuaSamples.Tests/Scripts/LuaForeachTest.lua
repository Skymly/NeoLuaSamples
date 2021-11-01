--[[
for i,v in ipairs(table_name) do end
for k,v in pairs(table_name) do end
]]



--make sampledata
local t1 = { 77 , 32 , 43 , 45 , 58  };
local lson1 = table.ToLson(t1,false);


local t2 = {
	["IOS"] = 1234554,
	["Android"] = 4465454,
	["MacOS"] = 5454654,
	["Linux"] = 455624,
	["Windows"] = 6546540
};
local lson2 = table.ToLson(t2,false);

print("\n".."foreach  ".. type(t1)  .."\t" .. lson1)
foreach item in t1 do
	print(item.Key..'\t'..item.Value)--item是KeyValuePair<object,object>
end

print("\n".."foreach  ".. type(t2) .."\t" .. lson2)
foreach item in t2 do
	print(item.Key..'\t'..item.Value)--item是KeyValuePair<object,object>
end
print("\n".."foreach  " .. array.GetType().."\t" .. json)
foreach	item in array do 
	print(item)
end



