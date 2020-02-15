import React from 'react';
import './CardProduct.css'

const CardProduct = ({imgSrc, name, price}) =>{
    return(
        <div className ="Mycard">
            <div className="mycard shadow">
                <div className="mycard-show">
                    <img src= {imgSrc}></img>
                    <p><b>{name}</b></p>
                    <p className="product_price">{price}</p>
                </div>
                <div className="mycard-hide">
                    <button><i class="fa fa-cart-plus"></i></button>
                </div>
            </div>
        </div>
    );
};
export default CardProduct;