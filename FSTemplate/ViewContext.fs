namespace FSTemplate

open System.Collections.Generic

type ViewContext = {
    tempData: IDictionary<string, obj>
    viewData: IDictionary<string, obj>
    model: obj
}


