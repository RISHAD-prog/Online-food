import { Link } from "react-router-dom";

const Navbar = () => {
    return (
        <div className="navbar bg-base-100">
            <div className="flex-1">
                <Link to="/" className="btn btn-ghost normal-case text-xl">Khadok_World</Link>
            </div>
            <div className="flex-none">
                <ul className="menu menu-horizontal px-1">
                <li><Link to="/login">Login</Link ></li>
                <li><Link to="/registration">SignUp</Link ></li>
                <li><Link to="/shop">Shop</Link ></li>
                </ul>
            </div>
        </div>
    );
};

export default Navbar;