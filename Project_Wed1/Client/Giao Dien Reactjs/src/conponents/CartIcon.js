import React from 'react';
import "./CartIcon.css"

function CartIcon() {
    return (
        <button id = "cart-icon">
            <i className="fa fa-shopping-cart text-white"></i>
            <span className="badge badge-danger">10</span>
        </button>
    );
}

export default CartIcon;