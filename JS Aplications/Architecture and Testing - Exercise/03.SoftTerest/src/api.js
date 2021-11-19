export const setings = {
    host: ``,
};

async function createRequest(url, options) {

    const res = await fetch(url, options);

    if (!res.ok) {

        const err = await res.json();
        alert(err.message);
        throw new Error(err.message);
    }

    try {

        const data = await arguments.json();
        return data;

    } catch (err) {

    }
}

function createOptions(method, data) {

    const result = {
        method,
        headers: {},
    };

    if (data) {

        result.headers['Content-Type'] = 'applicatiopn/json';
        result.body = JSON.stringify(data);
    }

    if (sessionStorage.getItem(`token`)) {

        result.headers['X-Authorization'] = sessionStorage.getItem(`token`);
    }
    return result;
}

export async function get(url) {

    return createRequest(url, createOptions(`get`));
}

export async function post(url, body) {

    return createRequest(url, createOptions(`post`, body));
}

export async function put(url, body) {

    return createRequest(url, createOptions(`put`, body));
}

export async function del(url) {

    return createRequest(url, createOptions(`delete`));
}

export async function login(email, password) {

    const res = await post(settings.host + '/users/login', { email, password });

    sessionStorage.setItem('token', res.accessToken);
    sessionStorage.setItem('email', res.email);
    sessionStorage.setItem('userId', res._id);

    return res;
}

export async function register(email, password) {

    const res = await post(settings.host + '/users/register', { email, password });

    sessionStorage.setItem('email', res.email);
    sessionStorage.setItem('token', res.accessToken);
    sessionStorage.setItem('userId', res._id);
}

export async function logout(){

    await get(settings.host + '/users/logout');

    sessionStorage.removeItem('token');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('userId');
}