local function ToJson(x)
    local SerializeObject = clr.Newtonsoft.Json.JsonConvert.SerializeObject;
    return SerializeObject(x);
end

local GenericList =  clr.System.Collections.Generic.List;
local Model = clr.Skymly.NeoLuaSamples.ConsoleApp.SampleModel;

local list1 = GenericList[Model]();

list1.Add(Model("刘备",30));
print(list1.Count);
list1.Add(Model("关羽",28));
print(list1.Count);
list1.Add(Model("张飞",25));
print(list1.Count);
print(ToJson(list1))


-- 使用 const 别名 typeof 泛型全名[泛型参数全名] 可以拥有更好的性能

const ListOfModel typeof System.Collections.Generic.List[Skymly.NeoLuaSamples.ConsoleApp.SampleModel];
local list2 = ListOfModel();
list2.Add(Model("aaa",55));
print(list2.Count);
list2.Add(Model("bbb",66));
print(list2.Count);
list2.Add(Model("ccc",77));
print(list2.Count);
print(ToJson(list2))
