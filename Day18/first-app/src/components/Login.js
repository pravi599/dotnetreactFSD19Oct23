// Login.js
import React, { useState } from "react";
import axios from "axios";
import './Login.css';

const roles = ["Select Role", "User", "Admin"];

const Login = () => {
    const initialFormData = {
        username: "",
        password: "",
        role: "Select Role"
    };

    const [formData, setFormData] = useState(initialFormData);
    const [errors, setErrors] = useState({});
    const [loginResult, setLoginResult] = useState(null);

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
        setErrors({ ...errors, [e.target.name]: "" }); // Clear the error when user starts typing
    };

    const checkUserData = () => {
        const { username, password, role } = formData;
        const newErrors = {};

        if (!username) newErrors.username = "Username cannot be empty";
        if (!password) newErrors.password = "Password cannot be empty";
        if (role === "Select Role") newErrors.role = "Please select a role";

        setErrors(newErrors);
        return Object.keys(newErrors).length === 0;
    };

    const login = async (event) => {
        event.preventDefault();

        if (!checkUserData()) return;

        try {
            // Use the appropriate API endpoint for login
            await axios.post("http://localhost:5203/api/Customer/Login", formData);
            setLoginResult({ success: true, message: "Login successful!" });
        } catch (err) {
            setLoginResult({ success: false, message: "Login failed. Please check your credentials." });
            console.log(err);
        } finally {
            setFormData(initialFormData); // Clear the form data after both success and failure
        }
    };

    return (
        <div className="loginContainer">
            <div className="loginBox">
                <h2 className="loginHeader">Login</h2>
                <form className="loginForm" noValidate>
                    {Object.entries(formData).map(([field, value]) => (
                        <div className="form-group" key={field}>
                            <label>
                                {field === "role"
                                    ? "Role"
                                    : field.charAt(0).toUpperCase() + field.slice(1)}
                            </label>
                            {field === "role" ? (
                                <select
                                    className="form-control"
                                    name={field}
                                    value={value}
                                    onChange={handleChange}
                                >
                                    {roles.map((r) => (
                                        <option value={r} key={r}>
                                            {r}
                                        </option>
                                    ))}
                                </select>
                            ) : (
                                <input
                                    type={field.includes("password") ? "password" : "text"}
                                    className="passwordInput"
                                    name={field}
                                    value={value}
                                    onChange={handleChange}
                                />
                            )}
                            {errors[field] && <span className="error">{errors[field]}</span>}
                        </div>
                    ))}

                    {loginResult && (
                        <div className={`alert ${loginResult.success ? 'alert-success' : 'alert-danger'} mt-3`}>
                            {loginResult.message}
                        </div>
                    )}

                    <div className="form-group mt-3">
                        <button className="btn btn-primary button-primary" onClick={login}>
                            Login
                        </button>
                        <button className="btn btn-danger button button-danger ml-2">Cancel</button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Login;

