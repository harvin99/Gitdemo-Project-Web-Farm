import React from 'react';
import './Search.css'

function Search() {
    return (
        <body>
            <div className="search border border-warning">
                <input placeholder="Search by name" type="text" class="search_input" />
                <a className="search_icon bg-warning border-warning">
                    <i className="fa fa-search"></i>
                </a>
            </div>
        </body>
    );
}

export default Search;