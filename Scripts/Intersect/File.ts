
module K {

    type Folder = {
        name: string;
        location: string;
    }

    type File = Folder & {
        size: number;
    }

    type ListItem = (File | Folder) & {
        icon: string;
    }

    let folder: Folder = { name: "", location: "" }
    let file: File = { name: "", location: "", size: 0 }
    let item1: ListItem = { name: "", location: "", icon: "" }
    let item2: ListItem = { name: "", location: "", size: "", icon: " " }

}