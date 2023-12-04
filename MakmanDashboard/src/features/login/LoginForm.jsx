import { useForm } from 'react-hook-form';
import { Link } from 'react-router-dom';
import styled from 'styled-components';
import { Button, Form, FormRow, Input } from '../../components';
import { useLogin } from '../../hooks/useLogin';

const Title = styled.h4`
  color: var(--primary-900);
`;

export const LoginForm = ({ title }) => {
  const { loginUser, isLoading } = useLogin();

  const {
    register,
    handleSubmit,
    formState: { isDirty, isValid, errors },
  } = useForm({
    mode: 'all',
  });

  const canSubmit = !(isDirty && isValid);

  const onSubmit = data => {
    const { email, password } = data;

    loginUser({ email, password });
  };

  return (
    <>
      <Form onSubmit={handleSubmit(onSubmit)} className='login-form'>
        <FormRow>
          {title && <Title className='form-title'>{title}</Title>}
        </FormRow>

        <FormRow error={errors?.email?.message}>
          <Input
            type='text'
            {...register('email', {
              required: 'This field is required',
              pattern: {
                value: /\S+@\S+\.\S+/,
                message: 'Entered value does not match email format',
              },
            })}
            placeholder='Email'
            hasError={!!errors?.email?.message}
          />
        </FormRow>

        <FormRow error={errors?.password?.message}>
          <Input
            type='password'
            {...register('password', {
              required: 'This field is required',
            })}
            placeholder='Password'
            hasError={!!errors?.password?.message}
          />
        </FormRow>

        <FormRow>
          <Button
            type='submit'
            variation='primary'
            disabled={canSubmit || isLoading}
          >
            Log In
          </Button>
        </FormRow>

        <FormRow>
          <span>
            Need an account <Link to='/registration'>sign up</Link>
          </span>
        </FormRow>
      </Form>
    </>
  );
};
