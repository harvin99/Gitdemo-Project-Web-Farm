export const getItem =(name)=>{
    const cookie =document.cookie;
    let regex =new RegExp (`(?<=${name}=).+(?=;)`)
    return cookie.match(regex);
}
export const setItem =(name,value)=>{
    const cookie =document.cookie;
    let regex =new RegExp (`(?<=${name}=).+(?=;)`)
    console.log(regex)
    console.log(cookie.match(regex))
    return cookie.replace(regex,value);
}