import React from 'react';
import { useForm } from 'react-hook-form';
import { Link } from 'react-router-dom';
import styled from 'styled-components';
import profileIcon from '../../assets/profile.svg';
import { Button, Form, FormRow, Input } from '../../components';
import { useSignup } from '../../hooks/useSignup';

const Title = styled.h4`
  color: var(--primary-900);
`;

export const RegistrationForm = ({ title }) => {
  const [image, setImage] = React.useState('');
  const { signupUser, isLoading } = useSignup();

  const {
    register,
    getValues,
    handleSubmit,
    watch,
    formState: { isDirty, isValid, errors },
  } = useForm({
    mode: 'all',
  });

  const canSubmit = !(isDirty && isValid);

  const convert2base64 = file => {
    const reader = new FileReader();

    reader.onloadend = () => {
      setImage(reader.result.toString());
    };

    reader.readAsDataURL(file);
  };

  const onSubmit = data => {
    const { first_name, last_name, email, password } = data;

    signupUser({ image, first_name, last_name, email, password });
  };

  const uploadedImage = new Image();
  uploadedImage.url = image;

  React.useEffect(() => {
    const subscription = watch((value, { name, type }) => {
      if (name === 'profile' && type === 'change') {
        if (value.profile.length > 0) {
          convert2base64(value.profile[0]);
        }
      }
    });

    return () => subscription.unsubscribe();
  }, [watch]);

  return (
    <>
      <Form onSubmit={handleSubmit(onSubmit)} className='registration-form'>
        <FormRow>
          {title && <Title className='form-title'>{title}</Title>}
        </FormRow>

        <FormRow error={errors?.profile?.message}>
          <>
            <label htmlFor='profileImage'>
              <img
                src={image || profileIcon}
                alt='upload-picture'
                width={80}
                height={80}
              />
            </label>
            <Input
              id='profileImage'
              style={{ display: 'none' }}
              type='file'
              accept='image/png'
              {...register('profile')}
              hasError={!!errors?.profile?.message}
            />
          </>
        </FormRow>

        <FormRow error={errors?.first_name?.message}>
          <Input
            type='text'
            {...register('first_name', {
              required: 'This field is required',
            })}
            placeholder='First Name'
            hasError={!!errors?.first_name?.message}
          />
        </FormRow>

        <FormRow error={errors?.last_name?.message}>
          <Input
            type='text'
            {...register('last_name', {
              required: 'This field is required',
            })}
            placeholder='Last Name'
            hasError={!!errors?.last_name?.message}
          />
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

        <FormRow error={errors?.confirmPassword?.message}>
          <Input
            type='password'
            {...register('confirmPassword', {
              required: 'This field is required',
              validate: value =>
                value === getValues().password || 'Passwords need to match',
            })}
            placeholder='confirm password'
            hasError={!!errors?.confirmPassword?.message}
          />
        </FormRow>

        <FormRow>
          <Button
            type='submit'
            variation='primary'
            disabled={canSubmit || isLoading}
          >
            Sign Up
          </Button>
        </FormRow>

        <FormRow>
          <span>
            Already have an account <Link to='/login'>log in</Link>
          </span>
        </FormRow>
      </Form>
    </>
  );
};
