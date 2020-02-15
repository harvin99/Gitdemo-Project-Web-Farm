import React, { useState } from "react";
import CardProduct from './CardProduct';
import './ListProduct.css'

const ListProduct = props => {
    const initState = [
        {
            imgSrc: "./1.jpg",
            name: "Ca Chua",
            price: "20.000 VND",
        },
        {
            imgSrc: "./1.jpg",
            name: "Cam",
            price: "20.000 VND",
        },
        {
            imgSrc: "./1.jpg",
            name: "Dua",
            price: "20.000 VND",
        },
        {
            imgSrc: "./1.jpg",
            name: "Cam",
            price: "20.000 VND",
        },
        {
            imgSrc: "./1.jpg",
            name: "Tao",
            price: "20.000 VND",
        }
    ];
    const [state, setState] = useState(initState);
    const ListProducts = state.map((productItem, i) => {
        return (
            <CardProduct {...productItem} key={i} />
        );
    });

    return (
        <div className = "listproduct">
            {ListProducts}
        </div>
    );
};
export default ListProduct;