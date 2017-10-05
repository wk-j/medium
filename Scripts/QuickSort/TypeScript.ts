let quick = (ls: number[]) => {
    if (ls.length > 0) {
        let h = ls[0];
        return quick(ls.filter(x => x < h))
            .concat(ls.filter(x => x == h))
            .concat(quick(ls.filter(x => x > h)));
    } else {
        return [];
    }
}

console.log(quick([1,5,2,3,8,4]));