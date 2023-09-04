import { useState } from "react";
import { useForm } from "react-hook-form";

const Registration = () => {
    const [checked, setChecked]= useState(false);
    const [passwordVisible, setPasswordVisible] = useState(true);
    const [conPasschecked, setConPassChecked] = useState(false);
    const [conPasswordVisible, setconPasswordVisible] = useState(true);
    const { register, handleSubmit, reset, formState: { errors } } = useForm();
    const handlePassToggle= ()=>{
            setChecked(!checked);
            setPasswordVisible(!passwordVisible);
       
    }
    const handleConToggle= ()=>{
        setConPassChecked(!conPasschecked);
        setconPasswordVisible(!conPasswordVisible);
   
}
    const addUser = (username, email, password, role) =>{
        const data = {
            username: username,
            email : email,
            password: password,
            role : role
        };
        fetch('https://localhost:44389/api/registration/addUser', {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify(data)
        })
            .then(res => res.json())
            .catch(error => alert(error.message))
    }
    let error = "";
    const onSubmit = data => {
        console.log(data);
        if (data.password !== data.conPass) {
            error = <span className=" text-red-500 " >Password does not match</span>
            return error;
        }
        
        addUser(data.username, data.email, data.password, "customer");
        reset();
        alert("user added");

            }
    return (
        <div className="hero min-h-screen bg-base-200">
            <div className="hero-content flex-col lg:flex-row-reverse">
                
                <div className="card flex-shrink-0 w-full max-w-sm shadow-2xl bg-base-100">
                <div className="card-body">
                <h1 className="text-5xl font-bold">SignUp now!</h1>
                <div className="form-control">
                    
                    <label className="label">
                        <span className="label-text">UserName</span>
                    </label>
                    <input type="text" placeholder="UserName" {...register("username", { required: true, minLength: 7, maxLength: 20 })} className="input input-bordered" />
                    {errors.username?.type === 'required' && <span className=" text-red-500 " >Name field is required</span>}
                    </div>
                    <div className="form-control">
                    
                    <label className="label">
                        <span className="label-text">Email</span>
                    </label>
                    <input type="text" placeholder="email" {...register("email", { required: true, minLength: 7, maxLength: 30 })} className="input input-bordered" />
                    {errors.email?.type === 'required' && <span className=" text-red-500 " >Email field is required</span>}
                    </div>
                    <div className="form-control">
                    <label className="label">
                        <span className="label-text">Password</span>
                    </label>
                    <input type={passwordVisible? "password":"text"} {...register("password", { required: true, minLength: 7, maxLength: 20, pattern: /(?=.*[A-Z])(?=.*[@$!%*?&])(?=.*[0-9])(?=.*[a-z])/ })} placeholder="User password"  className="input input-bordered" />
                    {errors.password?.type === 'required' && <span className=" text-red-500 " >Password field is required</span>}
                            {errors.password?.type === 'minLength' && <span className=" text-red-500 " >Password must have 6 characters</span>}
                            {errors.password?.type === 'maxLength' && <span className=" text-red-500 " >Password must be less than 20 characters</span>}
                            {errors.password?.type === 'pattern' && <span className=" text-red-500 " >Password must have at least one uppercase letter, one lowercase letter, one number and one special character</span>}
                    </div>
                    <div className="form-control w-52">
                        <label className="cursor-pointer label">
                        <input type="checkbox" className="toggle toggle-primary" checked={!checked} onClick={handlePassToggle} />
                        
                        </label>
                    </div>
                    <div className="form-control">
                    <label className="label">
                        <span className="label-text">Confirm Password</span>
                    </label>
                    <input type={conPasswordVisible? "password":"text"} {...register("conPass", { required: true, minLength: 7, maxLength: 20 })} placeholder="Confirm password" className="input input-bordered" />
                    {errors.conPass?.type === 'required' && <span className=" text-red-500 " >Password field is required</span>}
                    </div>
                    <div className="form-control w-52">
                        <label className="cursor-pointer label">
                        <input type="checkbox" className="toggle toggle-primary" checked={!conPasschecked} onClick={handleConToggle} />
                        </label>
                    
                    </div>
                    <div className="form-control mt-6">
                    <button className="btn btn-primary" onClick={handleSubmit(onSubmit)}>SignUp</button>
                    </div>
                </div>
                <p className="text-center p-5">By signing up, you agree to our Terms and Conditions and Privacy Policy.</p>
                </div>
            </div>
        </div>
    );
};

export default Registration;